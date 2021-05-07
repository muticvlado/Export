using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.OleDb;
using System.Globalization;

namespace IzvozKalkulacija_MPP2
{
    public partial class Izvoz : Form
    {
        OleDbConnection con = null;
        string conString = "";

        public Izvoz()
        {
            InitializeComponent();
        }

        private void btnIzvezi_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtOd.Text) && !String.IsNullOrWhiteSpace(tbProdavnica.Text))
                Kreiraj_Dokument(tbIzvoz.Text + "K-" + txtOd.Text + ".xml");
            else
            {
                MessageBox.Show("Da li ste uneli broj kalkulacije ili broj prodavnice?");
                txtOd.Focus();
            }
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            if (txtOd.Text == "")
                MessageBox.Show("Unesite broj kalkulacije koju zelite da izvezete!");
            else
            {
                if (tbPutanja.Text != "")
                {
                    conString = tbPutanja.Text;
                    Ucitaj();
                }
                else
                {
                    DialogResult dr = openFileDialog.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        conString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + openFileDialog.FileName;
                        tbPutanja.Text = conString;
                        string putanjaDoBaze = openFileDialog.FileName;
                        string[] sekvence = putanjaDoBaze.Split('\\');
                        string folder = "";
                        for (int i = 0; i < sekvence.Length - 1; i++)
                        {
                            folder += sekvence[i] + '\\';
                        }
                        tbIzvoz.Text = folder;
                        Ucitaj();
                    }
                }
            }
        }

        public void Ucitaj()
        {
            if (dgwZaglavlja.Columns.Count > 0)
            {
                dgwZaglavlja.Columns.Clear();
            }

            con = new OleDbConnection(conString);

            try
            {
                using (con)
                {
                    int odBroja;
                    //int doBroja;

                    int.TryParse(txtOd.Text, out odBroja);
                    //int.TryParse(txtDo.Text, out doBroja);

                    string QueryZag = "SELECT DISTINCT KKomintenti.SIF_KOM, KKomintenti.naziv, KKomintenti.adresa, KKomintenti.mesto, KKomintenti.drzava, KKomintenti.telefon, KKomintenti.e_mail, KKomintenti.napomena, KKomintenti.regbr, Kprijemnica.sif_pri, Kprijemnica.broj_pri_num, Kprijemnica.broj_pri, Kprijemnica.datum_pri, Kprijemnica.IDMagacina ";
                    QueryZag += "FROM Mroba INNER JOIN((Kprijemnica INNER JOIN Kstavke_pri ON Kprijemnica.sif_pri = Kstavke_pri.sif_pri) INNER JOIN KKomintenti ON Kprijemnica.sif_kom = KKomintenti.SIF_KOM) ON Mroba.sifra_int = Kstavke_pri.pri_sif_pro ";
                    QueryZag += "WHERE (Kprijemnica.broj_pri_num = ?)";// And (Kprijemnica.broj_pri_num <= ?)";

                    string querySta = "SELECT Kprijemnica.sif_pri, Kprijemnica.broj_pri_num, Kprijemnica.broj_pri, Kprijemnica.datum_pri, Kstavke_pri.sif_det_pri, Kstavke_pri.sif_pri, Kstavke_pri.pri_sif_pro, Kstavke_pri.rb, Kstavke_pri.kolicina, Kstavke_pri.pri_cena, ";
                    querySta += "Kstavke_pri.rabat, Kstavke_pri.rabat_izn, Kstavke_pri.predporez, Kstavke_pri.predporez_izn AS PrethodniPorez, Kstavke_pri.predporez_izn, Kstavke_pri.nabCena, Kstavke_pri.marza, Kstavke_pri.marza_iznos, Kstavke_pri.porez, Kstavke_pri.porez_izn, ";
                    querySta += "Kstavke_pri.prod_cena_nova, Kstavke_pri.porez_vp, CStr(Val(Mid([sifra_str],2))) As Sifra, Mroba.sifra_int, Mroba.naziv, Mroba.sif_JM ";
                    querySta += "FROM Mroba INNER JOIN((Kprijemnica INNER JOIN Kstavke_pri ON Kprijemnica.sif_pri = Kstavke_pri.sif_pri) INNER JOIN KKomintenti ON Kprijemnica.sif_kom = KKomintenti.SIF_KOM) ON Mroba.sifra_int = Kstavke_pri.pri_sif_pro ";
                    querySta += "WHERE(((Kprijemnica.broj_pri_num) =?))"; // And(Kprijemnica.broj_pri_num) <=?))";

                    OleDbCommand comZaglavlje = new OleDbCommand();
                    comZaglavlje.Connection = con;
                    comZaglavlje.CommandType = CommandType.Text;
                    comZaglavlje.CommandText = QueryZag;
                    comZaglavlje.Parameters.Add(new OleDbParameter("Od", OleDbType.Integer)).Value = odBroja;
                    //comZaglavlje.Parameters.Add(new OleDbParameter("Do", OleDbType.Integer)).Value = doBroja;
                    OleDbDataAdapter adapterZaglavlje = new OleDbDataAdapter(comZaglavlje);

                    DataSet dsZaglavlje = new DataSet();
                    adapterZaglavlje.Fill(dsZaglavlje);
                    bsZaglavlje.DataSource = dsZaglavlje.Tables[0].DefaultView;
                    dgwZaglavlja.DataSource = bsZaglavlje;

                    OleDbCommand comStavke = new OleDbCommand();
                    comStavke.Connection = con;
                    comStavke.CommandType = CommandType.Text;
                    comStavke.CommandText = querySta;
                    comStavke.Parameters.Add(new OleDbParameter("Od", OleDbType.Integer)).Value = odBroja;
                    //comStavke.Parameters.Add(new OleDbParameter("Do", OleDbType.Integer)).Value = doBroja;
                    OleDbDataAdapter adapterStavke = new OleDbDataAdapter(comStavke);

                    DataSet dsStavke = new DataSet();
                    adapterStavke.Fill(dsStavke);
                    bsStavke.DataSource = dsStavke.Tables[0].DefaultView;
                    dgwStavke.DataSource = bsStavke;

                    FormirajIdDokumenata();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public void FormirajIdDokumenata()
        {
            int id = 1;

            dgwZaglavlja.Columns.Add("DokumentId", "DokumentId");

            foreach(DataGridViewRow red in dgwZaglavlja.Rows)
            {
                if (!String.IsNullOrEmpty(red.Cells[0].Value + ""))
                {
                    red.Cells["DokumentId"].Value = id;
                    id++;
                }
            }
        }

        public void Kreiraj_Dokument(string imeFajla)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create(imeFajla))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Dokumenti");

                    Element_Dokumenti(writer);
                    Element_Poslovni_Partneri(writer);
                    Element_Magacini(writer);
                    Element_Kalkulacija(writer);
                    Element_Artikli(writer);
                    Element_Stavka_Kalkulacije(writer);
                    Element_Trosak(writer);
                    Element_Trosak_kalkulacija(writer);

                    writer.WriteEndElement();
                    writer.WriteEndDocument();                   

                    MessageBox.Show("Uspesno ste izvezli podatke.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public void Element_Dokumenti(XmlWriter w)
        {
            foreach (DataGridViewRow red in dgwZaglavlja.Rows)
            {
                if (!String.IsNullOrEmpty(red.Cells[0].Value + ""))
                {
                    w.WriteStartElement("Dokumenti");
                    
                    w.WriteElementString("Dokument_ID", red.Cells["DokumentId"].Value + "");
                    w.WriteElementString("Tip", "Kalkulacija");
                    DateTime datum = Convert.ToDateTime(red.Cells[12].Value);
                    w.WriteElementString("Datum_x0020_nastanka", datum.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));

                    w.WriteEndElement();
                }
            }
        }

        public void Element_Poslovni_Partneri(XmlWriter w)
        {
            foreach (DataGridViewRow red in dgwZaglavlja.Rows)
            {
                if (!String.IsNullOrEmpty(red.Cells[0].Value + ""))
                {
                    w.WriteStartElement("Poslovni_partneri");

                    w.WriteElementString("pp_poslovni_partner_id", red.Cells[0].Value + "");
                    w.WriteElementString("Šifra_x0020_dosijea", red.Cells[8].Value + "");
                    w.WriteElementString("Naziv", red.Cells[1].Value + "");
                    w.WriteElementString("Adresa", red.Cells[2].Value + "");
                    w.WriteElementString("Mesto", red.Cells[3].Value + "");
                    w.WriteElementString("Drzava", red.Cells[4].Value + "");
                    w.WriteElementString("Telefon", red.Cells["telefon"].Value + "");
                    w.WriteElementString("Email", red.Cells["e_mail"].Value + "");
                    w.WriteElementString("Napomena", red.Cells["napomena"].Value + "");
                    w.WriteElementString("Pib", red.Cells[8].Value + "");
                    w.WriteElementString("Pdv_x0020_obveznik", "1");
                    w.WriteElementString("Status", "Aktivan");

                    w.WriteEndElement();
                }
            }
        }

        public void Element_Magacini(XmlWriter w)
        {
            foreach (DataGridViewRow red in dgwZaglavlja.Rows)
            {
                if (!String.IsNullOrEmpty(red.Cells[0].Value + ""))
                {
                    w.WriteStartElement("Magacini");

                    w.WriteElementString("am_magacin_id", red.Cells["IDMagacina"].Value + "");
                    w.WriteElementString("Šifra_x0020_magacina", red.Cells["IDMagacina"].Value + "");
                    w.WriteElementString("Naziv", "Magacin " + red.Cells["IDMagacina"].Value);
                    w.WriteElementString("Način_x0020_vođenja", "2");
                    w.WriteElementString("Vrsta_x0020_artikla", "0");
                    w.WriteElementString("Adresa", "");
                    w.WriteElementString("Mesto", "");

                    w.WriteEndElement();
                }

                break;
            }
        }

        public void Element_Kalkulacija(XmlWriter w)
        {
            foreach (DataGridViewRow red in dgwZaglavlja.Rows)
            {
                if (!String.IsNullOrEmpty(red.Cells[0].Value + ""))
                {
                    w.WriteStartElement("Kalkulacija");

                    w.WriteElementString("Šifra_x0020_preduzeca", "");
                    w.WriteElementString("mk_kalkulacija_id", red.Cells[9].Value + "");
                    w.WriteElementString("mk_dokument_id", red.Cells["DokumentId"].Value + "");
                    w.WriteElementString("pp_poslovni_partner_id", red.Cells[0].Value + "");
                    w.WriteElementString("Šifra_x0020_partnera", red.Cells["regbr"].Value + "");
                    w.WriteElementString("am_magacin_id", red.Cells["IDMagacina"].Value + "");
                    w.WriteElementString("Šifra_x0020_magacina", red.Cells["IDMagacina"].Value + "");
                    w.WriteElementString("Status", "3");
                    w.WriteElementString("Poslovni_x0020_partner", "");
                    w.WriteElementString("Broj_x0020_dokumenta", red.Cells["broj_pri_num"].Value + "-" + tbProdavnica.Text);
                    w.WriteElementString("Broj_x0020_prijemnice", red.Cells["broj_pri"].Value + "");
                    DateTime datum = Convert.ToDateTime(red.Cells[12].Value);
                    w.WriteElementString("Datum_x0020_važenja", datum.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
                    w.WriteElementString("Vrsta_x0020_kalkulacije", "0");
                    w.WriteElementString("Napomena", "");
                    w.WriteElementString("Broj_x0020_za_x0020_knjizenje", "");
                    w.WriteElementString("Partner_x0020_naziv", red.Cells[1].Value + "");
                    w.WriteElementString("Partner_x0020_mesto", red.Cells[3].Value + "");
                    w.WriteElementString("Partner_x0020_adresa", red.Cells[2].Value + "");

                    w.WriteEndElement();
                }
            }
        }

        public void Element_Artikli(XmlWriter w)
        {
            foreach (DataGridViewRow red in dgwStavke.Rows)
            {
                if (!String.IsNullOrEmpty(red.Cells[0].Value + ""))
                {
                    w.WriteStartElement("Artikli");

                    w.WriteElementString("am_artikal_id", red.Cells[23].Value + "");
                    w.WriteElementString("Šifra_x0020_artikla", red.Cells[22].Value + "");
                    w.WriteElementString("Naziv", red.Cells[24].Value + "");
                    w.WriteElementString("Bar_x0020_kod", red.Cells[22].Value + "");
                    w.WriteElementString("Jedinica_x0020_mere", red.Cells[25].Value + "");
                    w.WriteElementString("Vrsta_x0020_artikla", "0");
                    w.WriteElementString("Poreska_x0020_stopa", red.Cells[18].Value + "");
                    double stopa = Convert.ToDouble(red.Cells["Porez"].Value.ToString());
                    if(stopa == 0.2)
                        w.WriteElementString("Tip_x0020_poreske_x0020_stope", "3");
                    else
                        w.WriteElementString("Tip_x0020_poreske_x0020_stope", "4");


                    w.WriteElementString("Pasivan", "0");                    

                    w.WriteEndElement();
                }
            }
        }

        public void Element_Stavka_Kalkulacije(XmlWriter w)
        {
            int rb = 1;
            foreach (DataGridViewRow red in dgwStavke.Rows)
            {
                if (!String.IsNullOrEmpty(red.Cells[0].Value + ""))
                {
                    decimal Kolicina = Convert.ToDecimal(red.Cells["kolicina"].Value);
                    decimal Stopa = Convert.ToDecimal(red.Cells["porez"].Value); // 0.1 ili 0.2
                    decimal PrethodniPorez = Convert.ToDecimal(red.Cells["predporez_izn"].Value) / Kolicina; // iznos prethodnog poreza po jednom komadu
                    decimal FakturnaCena = Convert.ToDecimal(red.Cells["pri_cena"].Value); // osnovna cena sa porezom bez rabata
                    decimal BrutoFakturnaVrednost = Kolicina * FakturnaCena;
                    decimal RabatProcenat = Convert.ToDecimal(red.Cells["rabat"].Value); // 0.05 je 5%
                    decimal RabatIznos = Convert.ToDecimal(red.Cells["rabat_izn"].Value) / Kolicina; // iznos rabata po jednom komadu
                    decimal NabavnaCena = Convert.ToDecimal(red.Cells["nabCena"].Value); // + PrethodniPorez; // cena sa rabatom i
                    decimal FakturnaVrednost = Kolicina * NabavnaCena;
                    
                    
                    decimal CenaBPdv = Convert.ToDecimal(red.Cells["nabCena"].Value) + Convert.ToDecimal(red.Cells["marza_iznos"].Value);
                    decimal CenaSPdv = Convert.ToDecimal(red.Cells["prod_cena_nova"].Value);
                    decimal RucPostotak = (CenaBPdv - NabavnaCena) / NabavnaCena;
                    decimal RucIznos = CenaBPdv - Convert.ToDecimal(red.Cells["nabCena"].Value);


                    w.WriteStartElement("Stavka_kalkulacije");                

                    w.WriteElementString("mk_kalkulacija_id", red.Cells["Kprijemnica.sif_pri"].Value + "");   
                    w.WriteElementString("am_artikal_id", red.Cells["sifra_int"].Value + "");       
                    w.WriteElementString("Redni_x0020_broj", rb + "");      

                    double fps = Convert.ToDouble(red.Cells["Porez"].Value);                  
                    int fpsInt = (int)(fps*10);

                    if (fpsInt == 2)
                    {
                        w.WriteElementString("Fakturna_x0020_poreska_x0020_stopa", "0.2");
                    }
                    else
                    {
                        w.WriteElementString("Fakturna_x0020_poreska_x0020_stopa", "0.1");
                    }

                    w.WriteElementString("Kolicina", DecimalFormat(Kolicina) + "");
                    w.WriteElementString("Fakturna_x0020_vrednost", DecimalFormat(FakturnaVrednost) + ""); 
                    w.WriteElementString("Zavisni_x0020_troškovi", "0.0000");
                    w.WriteElementString("Carinski_x0020_troškovi", "0.0000");
                    w.WriteElementString("Poreski_x0020_troškovi", "0.0000");
                    w.WriteElementString("Nabavna_x0020_cena", DecimalFormat(NabavnaCena) + "");
                    w.WriteElementString("Nabavna_x0020_vrednost", DecimalFormat(NabavnaCena * Kolicina) + "");
                    w.WriteElementString("Prethodni_x0020_porez", DecimalFormat(PrethodniPorez * Kolicina) + "");
                    w.WriteElementString("Razlika_x0020_u_x0020_ceni_x0020_procenat", DecimalFormat(RucPostotak) + ""); 
                    w.WriteElementString("Razlika_x0020_u_x0020_ceni_x0020_iznos", DecimalFormat(RucIznos) + ""); 
                    w.WriteElementString("Cena", DecimalFormat(CenaBPdv) + "");
                    w.WriteElementString("Cena_x0020_sa_x0020_porezom", CenaSPdv + "");

                    w.WriteElementString("Bruto_x0020_fakturna_x0020_vrednost", DecimalFormat(BrutoFakturnaVrednost) + "");
                    w.WriteElementString("Rabat_x0020_dobavljača",  DecimalFormat(RabatProcenat) + "");                 
                    w.WriteElementString("Artikal_x0020_poreska_x0020_stopa", DecimalFormat(Stopa) + "");

                    w.WriteElementString("Artikal_x0020_šifra", red.Cells["sifra_int"].Value + "");
                    w.WriteElementString("Artikal_x0020_naziv", red.Cells["naziv"].Value + "");
                    w.WriteElementString("Jedinica_x0020_mere_x0020_2", red.Cells["sif_JM"].Value + "");
                    w.WriteElementString("Količina_x0020_2", "0.0000");
                    w.WriteElementString("Nabavna_x0020_cena_x0020_2", "0.0000");
                    w.WriteElementString("Trošak_x0020_jedinični_x0020_2", "0.0000");
                    w.WriteElementString("Koeficijenat_x0020_2", "0.0000");
                    w.WriteElementString("Fakturna_x0020_vrednost_x0020_devizna", "0.0000");
                    w.WriteElementString("Akciza_x0020_trošak", "0.0000");
                    w.WriteElementString("Otpad_x0020_trošak", "0.0000");
                    w.WriteElementString("Fakturna_x0020_cena_x0020_devizna", "0.0000");

                    int stopaInt = (int)(Stopa * 10);
                    if (stopaInt == 2)
                    {
                        w.WriteElementString("Tip_x0020_poreske_x0020_stope", "3");
                        w.WriteElementString("Tip_x0020_fakturne_x0020_poreske_x0020_stope", "3");
                    }
                    else
                    {
                        w.WriteElementString("Tip_x0020_poreske_x0020_stope", "4");
                        w.WriteElementString("Tip_x0020_fakturne_x0020_poreske_x0020_stope", "4");
                    }

                    w.WriteEndElement();

                    rb++;
                }
            }
        }

        public void Element_Trosak(XmlWriter w)
        {
            w.WriteStartElement("Trosak");

            w.WriteElementString("mk_trosak_id", "");
            w.WriteElementString("Naziv", "");
            w.WriteElementString("Konto", "");
            w.WriteElementString("Tip", "");           

            w.WriteEndElement();
        }

        public void Element_Trosak_kalkulacija(XmlWriter w)
        {
            w.WriteStartElement("Trosak_kalkulacije");

            w.WriteElementString("mk_trosak_id", "");
            w.WriteElementString("mk_kalkulacija_id", "");
            w.WriteElementString("Naziv", "");
            w.WriteElementString("Iznos", "");
            w.WriteElementString("Konto", "");
            w.WriteElementString("Tip", "");
            w.WriteElementString("Dokument_x0020_ID", "");
            w.WriteElementString("Dokument", "");

            w.WriteEndElement();
        }



        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtOd.Text))
            {
                int kalk = 0;
                int.TryParse(txtOd.Text, out kalk);
                if (kalk != 0)
                    kalk++;
                txtOd.Text = kalk.ToString();
                Ucitaj();
                Kreiraj_Dokument(tbIzvoz.Text + "K-" + txtOd.Text + ".xml");
            }
            else
            {
                MessageBox.Show("Da li ste uneli broj kalkulacije?");
                txtOd.Focus();
            }            
        }

        private void btnLokacijaIzvoz_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialogIzvoz.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string lokZaIzvoz = folderBrowserDialogIzvoz.SelectedPath + "\\";                
                tbIzvoz.Text = lokZaIzvoz;
            }
        }

        public string DecimalFormat(decimal x)
        {
            string broj = "0.0000";

            CultureInfo ci = new CultureInfo("en-us");
            broj = x.ToString("F04", ci);
            return broj;
        }

        
    }   
}
