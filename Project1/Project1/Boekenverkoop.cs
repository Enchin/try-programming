using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
//info over printen te vinden op
//
//http://www.ondotnet.com/pub/a/dotnet/2002/06/24/printing.html
//
//
namespace Boekenverkoop
{
    class Printverkoop
    {
        private Klant klant;
        private double totaal = 0;//om het totaal van de faktuur in op te tellen
        private double krediet = 0;// om het bekomen krediet van binnengebrachte boeken in op te tellen
        private string sql;
        private SqlDB m_boeken;
        private string[,] tbl = new string[500, 2];
        private string verkdat = "";
        private string verkkort = "";
        private string verkrekID = "";
        private string verkklant = "";
        private bool iscredit = false;
        public Printverkoop()
        { }

        /// <summary>
        /// hier worden fakturen en creditnota's afgedrukt
        /// </summary>
        /// <param name="VerkRekeningId">faktuurnummer</param>
        /// <param name="leerl">bool geeft aan of het een leerling (true) of een leeraar is (false)</param>
        public void printverkoop(Int64 VerkRekeningId, bool leerl)
        {
            totaal = 0;
            #region ophalen gegevens
            sql = " select VerkDatum, VerkKorting, VerkRekeningId, VerkKlant, VerkCreditnota ";
            sql += " from tblVerkoop ";
            sql += "where VerkRekeningId = " + VerkRekeningId + " ;";
            m_boeken = new SqlDB();
            m_boeken.fillDataset("verkoop", sql, true);
            foreach (DataRow dr in m_boeken.DS.Tables["verkoop"].Rows)
            {
                verkdat = dr["VerkDatum"].ToString().Trim();
                verkkort = dr["VerkKorting"].ToString().Trim();
                verkrekID = dr["VerkRekeningId"].ToString().Trim();
                verkklant = dr["VerkKlant"].ToString().Trim();
                iscredit = Convert.ToBoolean(dr["VerkCreditnota"]);
            }
            klant = new Klant(Convert.ToInt64(verkklant), leerl);
            sql = "select tblVerkoopDetails.DetAantal , tblVerkoopDetails.DetPrijs , ";
            sql += "tblVerkoopDetails.DetArtId , tblVerkoopDetails.DetMaat , tblVerkoopDetails.TweedeHands, ";
            sql += "TblArtikel.artNaam ";
            sql += "from tblVerkoopDetails inner join TblArtikel on TblArtikel.artId=tblVerkoopDetails.DetArtId ";
            sql += "where tblVerkoopDetails.DetRekeningId = " + VerkRekeningId + " ; ";
            m_boeken = new SqlDB();
            m_boeken.fillDataset("verkdetail", sql, true);
            #endregion ophalen gegevens
            #region  Print settings
            //druk af; maar niet bewaren!
            PrintObject.CRelialblePrintObject myPrinter = new PrintObject.CRelialblePrintObject();
            //myPrinter.PrintDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            //myPrinter.PrintFaktuur(true, lling, VerkRekeningId, Convert.ToInt64(dtRow1["VerkRekeningId"]));  //false is geen credietnota!
            myPrinter.PrintDoc.DocumentName = "Boekenverkoop Faktuur " + VerkRekeningId;
            string Font = "Arial";
            float FontSize = 12;
            float PenWidth = 100;
            float spatie = 0;
            float PaginaBreedte;
            try
            {
                PaginaBreedte = myPrinter.PrintDoc.DefaultPageSettings.PaperSize.Width;
            }
            catch
            {
                MessageBox.Show("De printer is niet juist geconfigureerd!");
                return;
            }
            myPrinter.PrintDoc.DefaultPageSettings.Margins.Top = 00;
            myPrinter.PrintDoc.DefaultPageSettings.Margins.Bottom = 50;
            float kantlijn = 70;
            float kantlijn2 = PaginaBreedte * 60 / 100;
            float currRegel = 0;
            #endregion Print settings
            #region  Print heading
            // Print the heading
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "dit is een test", 1000, 1000, false, false, false, "TEXT", PenWidth, "black");
            myPrinter.AddObjectToList(Font, 14, kantlijn, currRegel, "VRIJ TECHNISCH INSTITUUT", 0, 0, false, false, false, "TEXT", PenWidth, "black");
            myPrinter.AddObjectToList(Font, 10, kantlijn2, currRegel, "Schooljaar " + DateTime.Today.Year.ToString() + "-" + Convert.ToString(DateTime.Today.Year + 1), 0, 0, true, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY);
            FontSize = 10;
            kantlijn2 = PaginaBreedte * 30 / 100;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "Boeveriestraat 73", 0, 0, false, false, false, "TEXT", PenWidth, "black");
            myPrinter.AddObjectToList(Font, FontSize, kantlijn2, currRegel, "Zandstraat 138", 0, 0, false, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 10;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "8000 Brugge", 0, 0, false, false, false, "TEXT", PenWidth, "black");
            myPrinter.AddObjectToList(Font, FontSize, kantlijn2, currRegel, "8200 Sint-Andries", 0, 0, false, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 10;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "(050) 33 35 02", 0, 0, false, false, false, "TEXT", PenWidth, "black");
            myPrinter.AddObjectToList(Font, FontSize, kantlijn2, currRegel, "(050) 31 66 12", 0, 0, false, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY);
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "", 0, PaginaBreedte - kantlijn, false, false, false, "LINE", 1, "black");

            // Klant invullen
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) + 10;
            FontSize = 10;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, klant.Naam.Trim() + " " + klant.Voornaam.Trim(), 0, 0, true, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 10;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, klant.Straat, 0, 0, true, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 10;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, klant.PostCode + " " + klant.Gemeente, 0, 0, true, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 10;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, klant.KlasId, 0, 0, true, false, false, "TEXT", PenWidth, "black");
            if (iscredit)
            {
                myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, (VerkRekeningId).ToString("Creditnota 70000"), 0, 0, false, false, false, "TEXT", PenWidth, "black");
            }
            else
            {
                myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, (VerkRekeningId).ToString("Faktuur 70000"), 0, 0, false, false, false, "TEXT", PenWidth, "black");
            }
            currRegel = Convert.ToUInt64(myPrinter.CurrentY);
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "", 0, PaginaBreedte - kantlijn, false, false, false, "LINE", 1, "black");
            #endregion Print heading
            #region Print Artikels
            float Kolom1 = kantlijn;
            float Kolom2 = kantlijn + 40;// (kantlijn / 3);
            float Kolom3 = kantlijn + 100;// *2;
            float Kolom4 = kantlijn + 200;
            float Kolom5 = PaginaBreedte - (kantlijn * 3);
            bool hoofd = true;// moet de hoofding van de paragrafe gedrukt worden?
                              // creditnota afdukken
            if (iscredit)
            {
                #region creditnota afdrukken
                FontSize = 10;
                currRegel = Convert.ToUInt64(myPrinter.CurrentY);// +spatie;
                myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "Onderstaande artikels werden teruggegeven en terug betaald.", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                currRegel = Convert.ToUInt64(myPrinter.CurrentY);// + spatie;
                FontSize = 9;
                foreach (DataRow dr in m_boeken.DS.Tables["verkdetail"].Rows)
                {
                    myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, Math.Abs(Convert.ToInt16(dr["DetAantal"])).ToString().Trim() + " st.", 0, 0, false, false, false, "TEXT", PenWidth, "black");
                    myPrinter.AddObjectToList(Font, FontSize, Kolom2, currRegel, "Ђ " + (Math.Abs(Convert.ToDouble(dr["DetPrijs"]))).ToString("##0.00").PadLeft(7, ' '), 0, 0, false, false, false, "TEXT", PenWidth, "black");//
                    myPrinter.AddObjectToList(Font, FontSize, Kolom3, currRegel, dr["DetArtId"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                    myPrinter.AddObjectToList(Font, FontSize, Kolom4, currRegel, dr["artNaam"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                    totaal += Convert.ToDouble(dr["DetPrijs"]) * (Math.Abs(Convert.ToDouble(dr["DetAantal"])));
                    currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
                    dr.Delete();
                }
                #endregion creditnota afdrukken
            }
            else
            {
                #region faktuur afdrukken
                // Artikels die werden betaald en meegenomen
                foreach (DataRow dr in m_boeken.DS.Tables["verkdetail"].Rows)
                {
                    if (Convert.ToBoolean(dr["TweedeHands"]) == false && (Convert.ToDouble(dr["DetPrijs"]) >= 0))
                    {
                        //MessageBox.Show(dr["DetAantal"].ToString());
                        if (Convert.ToInt16(dr["DetAantal"]) > 0)
                        {
                            if (hoofd)
                            {
                                FontSize = 10;
                                currRegel = Convert.ToUInt64(myPrinter.CurrentY);// +spatie;
                                myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "Onderstaande artikels werden betaald en door u meegenomen.", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                                currRegel = Convert.ToUInt64(myPrinter.CurrentY);// + spatie;
                                FontSize = 9;
                                hoofd = false;
                            }
                            myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, dr["DetAantal"].ToString().Trim() + "st.", 0, 0, false, false, false, "TEXT", PenWidth, "black");
                            myPrinter.AddObjectToList(Font, FontSize, Kolom2, currRegel, "Ђ " + (Convert.ToDouble(dr["DetPrijs"])).ToString("##0.00").PadLeft(7, ' '), 0, 0, false, false, false, "TEXT", PenWidth, "black");//
                            myPrinter.AddObjectToList(Font, FontSize, Kolom3, currRegel, dr["DetArtId"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                            myPrinter.AddObjectToList(Font, FontSize, Kolom4, currRegel, dr["artNaam"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                            totaal += Convert.ToDouble(dr["DetPrijs"]) * Convert.ToDouble(dr["DetAantal"]);
                            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
                            dr.Delete();
                        }
                    }
                }
                m_boeken.DS.Tables["verkdetail"].AcceptChanges();

                // artikels die besteld en betaald werden
                hoofd = true;
                foreach (DataRow dr in m_boeken.DS.Tables["verkdetail"].Rows)
                {
                    if (Convert.ToBoolean(dr["TweedeHands"]) == false)
                    {
                        if (Convert.ToInt16(dr["DetAantal"]) < 0)
                        {
                            if (hoofd)
                            {
                                FontSize = 10;
                                currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;

                                myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "Onderstaande artikels werden besteld en betaald.", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                                currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 5;
                                myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "Zodra ze bij ons in voorraad komen wordt u door ons verwittigd.", 0, 0, true, false, false, "TEXT", PenWidth, "black");

                                currRegel = Convert.ToUInt64(myPrinter.CurrentY);
                                FontSize = 9;
                                hoofd = false;
                            }
                            myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, (Math.Abs(Convert.ToInt16(dr["DetAantal"]))).ToString().Trim() + "st.", 0, 0, false, false, false, "TEXT", PenWidth, "black");
                            myPrinter.AddObjectToList(Font, FontSize, Kolom2, currRegel, "Ђ " + (Convert.ToDouble(dr["DetPrijs"])).ToString("##0.00").PadLeft(7, ' '), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                            myPrinter.AddObjectToList(Font, FontSize, Kolom3, currRegel, dr["DetArtId"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                            myPrinter.AddObjectToList(Font, FontSize, Kolom4, currRegel, dr["artNaam"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                            totaal += Convert.ToDouble(dr["DetPrijs"]) * Math.Abs(Convert.ToDouble(dr["DetAantal"]));

                            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
                            dr.Delete();
                        }
                    }
                }
                m_boeken.DS.Tables["verkdetail"].AcceptChanges();
                hoofd = true;
                foreach (DataRow dr in m_boeken.DS.Tables["verkdetail"].Rows)
                {
                    if (Convert.ToBoolean(dr["TweedeHands"]) == true)
                    {
                        if (hoofd)
                        {
                            FontSize = 10;
                            currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;
                            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "U kocht ook tweedehandse boeken.", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                            currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;
                            FontSize = 9;
                            hoofd = false;
                        }
                        myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, dr["DetAantal"].ToString().Trim() + "st.", 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        myPrinter.AddObjectToList(Font, FontSize, Kolom2, currRegel, "Ђ " + (Convert.ToDouble(dr["DetPrijs"])).ToString("##0.00").PadLeft(7, ' '), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        myPrinter.AddObjectToList(Font, FontSize, Kolom3, currRegel, dr["DetArtId"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        myPrinter.AddObjectToList(Font, FontSize, Kolom4, currRegel, dr["artNaam"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        totaal += Convert.ToDouble(dr["DetPrijs"]) * Convert.ToDouble(dr["DetAantal"]);
                        currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
                        dr.Delete();
                    }
                }
                m_boeken.DS.Tables["verkdetail"].AcceptChanges();
                // tweedehandsboeken binnengebracht voor verkoop
                hoofd = true;
                foreach (DataRow dr in m_boeken.DS.Tables["verkdetail"].Rows)
                {
                    if (Convert.ToDouble(dr["DetPrijs"]) < 0)
                    {
                        if (hoofd)
                        {
                            FontSize = 10;
                            currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;

                            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "U verkocht tweedehandse boeken.", 0, 0, true, false, false, "TEXT", PenWidth, "black");

                            currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;
                            FontSize = 9;
                            hoofd = false;
                        }
                        myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, dr["DetAantal"].ToString().Trim() + "st.", 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        myPrinter.AddObjectToList(Font, FontSize, Kolom2, currRegel, "Ђ " + Math.Abs((Convert.ToDouble(dr["DetPrijs"]))).ToString("##0.00").PadLeft(7, ' '), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        myPrinter.AddObjectToList(Font, FontSize, Kolom3, currRegel, dr["DetArtId"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        myPrinter.AddObjectToList(Font, FontSize, Kolom4, currRegel, dr["artNaam"].ToString().Trim(), 0, 0, false, false, false, "TEXT", PenWidth, "black");
                        krediet += Convert.ToDouble(dr["DetPrijs"]) * Convert.ToDouble(dr["DetAantal"]);
                        currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
                        dr.Delete();
                    }
                }
                m_boeken.DS.Tables["verkdetail"].AcceptChanges();
                #endregion faktuur afdrukken
            }
            #endregion Print Artikels
            #region Print Afrekening
            // Afrekening
            FontSize = 10;
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "Afrekening.", 0, 0, true, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 5;
            //    FontSize = 8;
            myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, " Het totaal voor de bovenstaande artikelen :", 0, 0, true, false, false, "TEXT", PenWidth, "black");
            myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, "Ђ " + Math.Abs(totaal).ToString(" ##0.00").PadLeft(7, ' '), 0, 0, true, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8 + spatie;

            if (krediet < 0)
            {
                myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "  Tegoed uit Tweedehandseboekenverkoop : ", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, "Ђ " + Math.Abs(krediet).ToString(" ##0.00").PadLeft(7, ' '), 0, 0, true, false, false, "TEXT", PenWidth, "black");
                totaal += krediet;
            }
            else
            {
                currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;
            }
            currRegel = Convert.ToUInt64(myPrinter.CurrentY);
            sql = "select betbetaalwijzeId ";
            sql += " from tblBetaling ";
            sql += "where BetRekeningId = " + VerkRekeningId + " ; ";
            m_boeken = new SqlDB();
            m_boeken.fillDataset("betaalwijze", sql, true);
            double korting = totaal * (Convert.ToDouble(verkkort)) / 100;

            totaal -= korting;
            if (korting != 0)
            {
                if (iscredit)
                {
                    myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "  U ontving bij ons een korting :", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                    myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, "Ђ " + korting.ToString("###0.00").PadLeft(7, ' '), 0, 0, true, false, false, "TEXT", PenWidth, "black");
                    currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;
                }
                else
                {
                    myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "  U ontvangt bij ons een korting :", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                    myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, "Ђ " + korting.ToString("###0.00").PadLeft(7, ' '), 0, 0, true, false, false, "TEXT", PenWidth, "black");
                }
            }
            else
            {
                currRegel = Convert.ToUInt64(myPrinter.CurrentY) + spatie;
            }
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) + 10;
            //double betBedrag = som - korting;
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
            if (iscredit)
            {
                myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, " Voor deze Creditnota krijgt U terug : ", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, "Ђ " + Math.Abs(totaal).ToString("###0.00").PadLeft(7, ' '), 0, 0, true, false, false, "TEXT", PenWidth, "black");
            }
            else
            {
                myPrinter.AddObjectToList(Font, FontSize, kantlijn, currRegel, "  U betaalde voor deze rekening : ", 0, 0, true, false, false, "TEXT", PenWidth, "black");
                myPrinter.AddObjectToList(Font, FontSize, PaginaBreedte * 6 / 10, currRegel, "Ђ " + totaal.ToString("###0.00").PadLeft(7, ' ') + " Ђ via " + m_boeken.DS.Tables["betaalwijze"].Rows[0][0], 0, 0, true, false, false, "TEXT", PenWidth, "black");
            }
            currRegel = Convert.ToUInt64(myPrinter.CurrentY);
            string voettekst = "";
            #region voettekst
            //Extra voettekst
            voettekst = "Aangekochte goederen worden NIET teruggenomen.";
            FontSize = 8;
            myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, voettekst, 0, 0, false, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
            voettekst = "Aa.";
            myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, voettekst, 0, 0, false, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
            voettekst = "Aa.";
            myPrinter.AddObjectToList(Font, FontSize, Kolom1, currRegel, voettekst, 0, 0, false, false, false, "TEXT", PenWidth, "black");
            currRegel = Convert.ToUInt64(myPrinter.CurrentY) - 8;
            #endregion voettekst
            #endregion Print Afrekening
            myPrinter.Print();
            krediet = 0;
            totaal = 0;
        }
    }
}
