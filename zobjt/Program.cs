using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zobjt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Op_unknown = false;

            float Op_scalex_val = 1.0F;
            float Op_scaley_val = 1.0F;
            float Op_scalez_val = 1.0F;
            float Op_scaleu_val = 1.0F;
            float Op_scalev_val = 1.0F;
            float Op_flipx_val = 1.0F;
            float Op_flipy_val = 1.0F;
            float Op_flipz_val = 1.0F;
            float Op_flipu_val = 1.0F;
            float Op_flipv_val = 1.0F;

            bool Op_triangle = false;

            bool Validasfloat(string sttr)
            {
                string stttr = "";
                for (int vv=0; vv<sttr.Length; vv=vv+1)
                {
                    bool dex = false;
                    string sfs = sttr.Substring(vv, 1);
                    if (
                        (sfs == "0") |
                        (sfs == "1") |
                        (sfs == "2") |
                        (sfs == "3") |
                        (sfs == "4") |
                        (sfs == "5") |
                        (sfs == "6") |
                        (sfs == "7") |
                        (sfs == "8") |
                        (sfs == "9") |
                        ((sfs == ".") & (!dex))
                        )
                    {
                        if (sfs == ".")
                        {
                            dex = true;
                        }
                        stttr = stttr + sfs;
                    }
                }
                return (sttr == stttr);
            }

            if (args.Length != null)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("ZAC's OBJ Tool");
                    Console.WriteLine("");
                    Console.WriteLine("Created by: TheZACAtac");
                    Console.WriteLine("Version: Beta");
                    Console.WriteLine("");
                    Console.WriteLine("Commands:");
                    Console.WriteLine("zobjt change SOURCE ...");
                    Console.WriteLine("  -changes certain aspects of SOURCE (an .obj file)");
                    Console.WriteLine("  -any of the following options can be used");
                    Console.WriteLine("     --scalex=VALUE");
                    Console.WriteLine("        Scales the x vertex values by VALUE");
                    Console.WriteLine("     --scaley=VALUE");
                    Console.WriteLine("        Scales the y vertex values by VALUE");
                    Console.WriteLine("     --scalez=VALUE");
                    Console.WriteLine("        Scales the z vertex values by VALUE");
                    Console.WriteLine("     --flipx");
                    Console.WriteLine("        Flips the x vertex values");
                    Console.WriteLine("     --flipy");
                    Console.WriteLine("        Flips the y vertex values");
                    Console.WriteLine("     --flipz");
                    Console.WriteLine("        Flips the z vertex values");
                    Console.WriteLine("     --scaleu=VALUE");
                    Console.WriteLine("        Scales the u texture mapping values by VALUE");
                    Console.WriteLine("     --scalev=VALUE");
                    Console.WriteLine("        Scales the v texture mapping values by VALUE");
                    Console.WriteLine("     --flipu");
                    Console.WriteLine("        Flips the u texture mapping values");
                    Console.WriteLine("     --flipv");
                    Console.WriteLine("        Flips the v texture mapping values");
                    Console.WriteLine("     --triangle");
                    Console.WriteLine("        Makes all the faces triangular");
                }
                if (args.Length >= 1)
                {
                    int Known = 0;
                    if (args[0].ToLower() == "change")
                    {
                        Known = 1;

                        string Fsource = args[1];


                        if (File.Exists(Fsource))
                        {
                            for (int nn = 2; nn < args.Length; nn = nn + 1)
                            {
                                Op_unknown = true;
                                if (args[nn].Length > 9)
                                {
                                    if (args[nn].Substring(0, 9) == "--scalex=")
                                    {
                                        Op_unknown = false;
                                        if (Validasfloat(args[nn].Substring(9)))
                                        {
                                            Op_scalex_val = float.Parse(args[nn].Substring(9));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Invalid value");
                                        }
                                    }

                                    if (args[nn].Substring(0, 9) == "--scaley=")
                                    {
                                        Op_unknown = false;
                                        if (Validasfloat(args[nn].Substring(9)))
                                        {
                                            Op_scaley_val = float.Parse(args[nn].Substring(9));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Invalid value");
                                        }
                                    }

                                    if (args[nn].Substring(0, 9) == "--scalez=")
                                    {
                                        Op_unknown = false;
                                        if (Validasfloat(args[nn].Substring(9)))
                                        {
                                            Op_scalez_val = float.Parse(args[nn].Substring(9));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Invalid value");
                                        }
                                    }

                                    if (args[nn].Substring(0, 9) == "--scaleu=")
                                    {
                                        Op_unknown = false;
                                        if (Validasfloat(args[nn].Substring(9)))
                                        {
                                            Op_scaleu_val = float.Parse(args[nn].Substring(9));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Invalid value");
                                        }
                                    }

                                    if (args[nn].Substring(0, 9) == "--scalev=")
                                    {
                                        Op_unknown = false;
                                        if (Validasfloat(args[nn].Substring(9)))
                                        {
                                            Op_scalev_val = float.Parse(args[nn].Substring(9));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Invalid value");
                                        }
                                    }
                                }

                                if (args[nn] == "--flipx")
                                {
                                    Op_unknown = false;
                                    Op_flipx_val = -1.0F;
                                }

                                if (args[nn] == "--flipy")
                                {
                                    Op_unknown = false;
                                    Op_flipy_val = -1.0F;
                                }


                                if (args[nn] == "--flipz")
                                {
                                    Op_unknown = false;
                                    Op_flipz_val = -1.0F;
                                }


                                if (args[nn] == "--flipu")
                                {
                                    Op_unknown = false;
                                    Op_flipu_val = -1.0F;
                                }


                                if (args[nn] == "--flipv")
                                {
                                    Op_unknown = false;
                                    Op_flipv_val = -1.0F;
                                }

                                if (args[nn] == "--triangle")
                                {
                                    Op_unknown = false;
                                    Op_triangle = true;
                                }

                                if (Op_unknown)
                                {
                                    Console.WriteLine("Error: Unknown Option");
                                }
                            }
                            string[] lines = System.IO.File.ReadAllLines(@Fsource);
                            //File.Delete(Fsource);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Fsource, false))
                            {
                                for (int nn = 0; nn < lines.Length; nn = nn + 1)
                                {
                                    bool special = false;
                                    string lll = lines[nn];
                                    if (lll.Length >= 2)
                                    {
                                        while (lll.Substring(0, 1) == " ")
                                        {
                                            lll = lll.Substring(1);
                                        }
                                        if (lll.Substring(0, 2) == "v ")
                                        {
                                            special = true;
                                            lll = lll.Substring(lll.IndexOf(" ") + 1) + " ";
                                            string xx = lll.Substring(0, lll.IndexOf(" "));
                                            lll = lll.Substring(lll.IndexOf(" ") + 1);
                                            string yy = lll.Substring(0, lll.IndexOf(" "));
                                            lll = lll.Substring(lll.IndexOf(" ") + 1);
                                            string zz = lll.Substring(0, lll.IndexOf(" "));
                                            file.WriteLine("v " + (float.Parse(xx) * Op_scalex_val * Op_flipx_val).ToString() + " " + (float.Parse(yy) * Op_scaley_val * Op_flipy_val).ToString() + " " + (float.Parse(zz) * Op_scalez_val * Op_flipz_val).ToString());
                                        }
                                        if (lll.Substring(0, 3) == "vt ")
                                        {
                                            special = true;
                                            lll = lll.Substring(lll.IndexOf(" ") + 1) + " ";
                                            string xx = lll.Substring(0, lll.IndexOf(" "));
                                            lll = lll.Substring(lll.IndexOf(" ") + 1);
                                            string yy = lll.Substring(0, lll.IndexOf(" "));

                                            file.WriteLine("vt " + (float.Parse(xx) * Op_scaleu_val * Op_flipu_val).ToString() + " " + (float.Parse(yy) * Op_scalev_val * Op_flipv_val).ToString());
                                        }
                                        if ( (lll.Substring(0, 2) == "f ") & (Op_triangle))
                                        {
                                            special = true;
                                            lll = lll.Substring(lll.IndexOf(" ") + 1) + " ;";
                                            while (lll.Substring(0, 1) == " ")
                                            {
                                                lll = lll.Substring(1);
                                            }
                                            string aa = lll.Substring(0, lll.IndexOf(" "));
                                            lll = lll.Substring(lll.IndexOf(" ") + 1);
                                            while (lll.Substring(0, 1) == " ")
                                            {
                                                lll = lll.Substring(1);
                                            }
                                            string bb = lll.Substring(0, lll.IndexOf(" "));
                                            lll = lll.Substring(lll.IndexOf(" ") + 1);
                                            while (lll.Substring(0, 1) == " ")
                                            {
                                                lll = lll.Substring(1);
                                            }
                                            string cc = lll.Substring(0, lll.IndexOf(" "));
                                            lll = lll.Substring(lll.IndexOf(" ") + 1);
                                            while (lll.Substring(0, 1) == " ")
                                            {
                                                lll = lll.Substring(1);
                                            }
                                            file.WriteLine("f " + aa + " " + bb + " " + cc);
                                            while (lll!=";")
                                            {
                                                bb = cc;
                                                cc = lll.Substring(0, lll.IndexOf(" "));
                                                lll = lll.Substring(lll.IndexOf(" ") + 1);
                                                while (lll.Substring(0, 1) == " ")
                                                {
                                                    lll = lll.Substring(1);
                                                }
                                                file.WriteLine("f " + aa + " " + bb + " " + cc);
                                            }
                                        }
                                    }
                                    if (!special)
                                    {
                                        file.WriteLine(lll);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Source file does not exist");
                        }
                    }
                    if (Known == 0)
                    {
                        Console.WriteLine("Error: Unknown Command");
                    }
                }
            }
        }
    }
}
