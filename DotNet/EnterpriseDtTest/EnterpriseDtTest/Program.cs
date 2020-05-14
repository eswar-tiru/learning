using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EnterpriseDT.Net.Ftp;
using EnterpriseDT.Net.Ftp.Ssh;
using EnterpriseDT.Net.Ssh;
using SBSimpleSftp;
using SBSSHKeyStorage;
using SBUtils;
using SBX509;
using PublicKey = EnterpriseDT.Net.Ssh.Routrek.PKI.PublicKey;

namespace EnterpriseDtTest
{
    class Program
    {
        private static byte[] edt;
        private static byte[] sbb;

        private static SBSSHKeyStorage.TElSSHKey sbbkey;
        private static PublicKey edtkey;

        private static string edtstring;


        public static void Main(string[] args)
        {
	        SBUtils.__Global.SetLicenseKey("7B0A4EDFB25FC655C2EA69AE540B9F5C6B28AE03FE65D85C1260529DEBB9B8FE1CA202F19415DCA4240AA70908D514E55EFDE622EB426259CB854D2B637DAC4C96B3599BBBA206841ACF143C80514AF748C35E223D553E51900A64580840E52A66DFC75FEFE52E531A2BA1DF9C5318845E1F8D9197E20AE33CB52C69AB43635A5035CA0884700A8DD763DC635D3D972D64B7932A48504B84B62374B6E0FF03E2F98B7EDB94C0C27A4D0F6223665C8046086C236EB49F97B33169E45CA68C99C0970C46E95D9063AFA11E2D2AAD094A407EEB56F8DB4AD15983806F7CA3960A19D519A66A73A878CED8430E044A4888381959C2E121A879E3E65E94A236C77A4F");
	        TElX509Certificate cert = new TElX509Certificate();
	        cert.LoadFromFileAuto("C:\\Users\\tcheemakurthy\\Desktop\\PrivateKey.pfx", "123456");
	        //var x = cert.Get;
	        X509Certificate
        }

        static void Main1(string[] args)
        {
            SecureFTPConnection connection = new SecureFTPConnection
            {
                LicenseOwner = "EZE11",
                LicenseKey = "064-7589-5000-7862",
                Protocol = FileTransferProtocol.SFTP,
                ServerValidation = SecureFTPServerValidationType.Callback,
                AuthenticationMethod = AuthenticationType.Password,
                ServerAddress = "qaftp.qalab.net",
                ServerPort = 22,
                UserName = "administrator",
                Password = "Boston09"
            };

            connection.ValidatingServer += connection_ValidatingServer;
            connection.Connect();
            connection.Close(false);

			 //SBUtils.__Global.SetLicenseKey("7B0A4EDFB25FC655C2EA69AE540B9F5C6B28AE03FE65D85C1260529DEBB9B8FE1CA202F19415DCA4240AA70908D514E55EFDE622EB426259CB854D2B637DAC4C96B3599BBBA206841ACF143C80514AF748C35E223D553E51900A64580840E52A66DFC75FEFE52E531A2BA1DF9C5318845E1F8D9197E20AE33CB52C69AB43635A5035CA0884700A8DD763DC635D3D972D64B7932A48504B84B62374B6E0FF03E2F98B7EDB94C0C27A4D0F6223665C8046086C236EB49F97B33169E45CA68C99C0970C46E95D9063AFA11E2D2AAD094A407EEB56F8DB4AD15983806F7CA3960A19D519A66A73A878CED8430E044A4888381959C2E121A879E3E65E94A236C77A4F");
			 //TElSimpleSFTPClient client = new TElSimpleSFTPClient
			 //{
			 //	Address = "socksproxy.qalab.net",
			 //	Port = 22,
			 //	Username = "administrator",
			 //	Password = "Boston09"
			 //};

			 //client.OnKeyValidate += client_OnKeyValidate;
			 //client.Open();
			 //client.Close(true);
             

         //   var detstr = ByteArrayToHexString(edt);
         //   var sbbstr = ByteArrayToHexString(sbb);
         //   Console.WriteLine(detstr);
         //   Console.WriteLine(sbbstr);

            var sbbkeyfromedt = new TElSSHKey();
                sbbkeyfromedt.LoadPublicKey(edt,edt.Length);
            var edtkeyfromsbb = new PublicKeyFactory().GeneratePublicKey(sbb);




            Console.WriteLine(edtstring);
        }

        static void client_OnKeyValidate(object Sender, SBSSHKeyStorage.TElSSHKey ServerKey, ref bool Validate)
        {
            sbb = new byte[4096];
            var length = 4096;
            ServerKey.SavePublicKey(ref sbb, ref length, TSBEOLMarker.emCRLF);
            Array.Resize(ref sbb, length);
            sbbkey = ServerKey;
            Validate = true;
            //TElSSHKey t = new TElSSHKey();
            //t.LoadPublicKey(edt, edt.Length);
            //var d = t.FingerprintSHA1.Equals(ServerKey.FingerprintSHA1);
            //Console.WriteLine(d);
            //Validate = d;
        }

        static void connection_ValidatingServer(object sender, ServerValidationEventArgs e)
        {
           // edtstring =  e.SSHPublicKey.ToStringOpenSSH("");

            edt = e.SSHPublicKey.ToByteArrayOpenSSH("my test");// test with a comment
            edtkey = e.SSHPublicKey;
            //edt = Encoding.UTF8.GetBytes(e.SSHPublicKey.ToStringOpenSSH("").Trim(),);
          //e.SSHPublicKey
          e.IsValid = true;
        }

        static string ByteArrayToHexString(byte[] certBinary)
        {
            StringBuilder sb = new StringBuilder(certBinary.Length * 2); // String takes 2 bytes in memory
            sb.Append("0x"); // To denote it's a hexadecimal string
            foreach (byte b in certBinary)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }

        //static string 
    }
}
