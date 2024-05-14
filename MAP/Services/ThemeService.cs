using MAP.Resources;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Apis.Auth.OAuth2;

namespace MAP.Services
{
	public class ThemeService: IThemeService
	{
		bool isKnowCurrentTheme = false;
		Theme _currentTheme = Theme.Default;	

		public Theme GetCurrentTheme()
		{
			//var fcb = new FirestoreClientBuilder();
			//fcb.JsonCredentials = "{\"type\": \"service_account\",  \"project_id\": \"mapfirebase-2e39e\", " +
			//"\"private_key_id\": \"914fd73168c4c7ca8e5d7a43fb44093d94595933\",  " +
			//"\"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCUXUVv2alZ7TAA\\nxQ8joeJwRGva2ZebtW05Mgu8NUSbp6GPrcs0KchucML9QX/5fI3TUkCuK5dhefW3\\n3SNLljXWfuuM5h05hnliB7Wgy2cGYZXneTkmZlPS5spmAR6meNA4I/GoFjKeLm+4\\njp6l4m2Hra2QFmYDHrWGPdiXdnh/UvP+TydSTRIEq1aIr6Zm40oN++yPLXf1JRKz\\n+4NJLXpfHLzvw6qyLHXK3KAYVdIFC4PAjcrRcI12t86wlr1YeMzgquRNU0lXWDVX\\nhMqLVOzcsMJjjxmJyEWZgsdGRJM00coowyn42OkEBenalf/kf3tOuLZmwaJJd6LQ\\n56OPKUrVAgMBAAECggEAPJ/GPVegK0ZPzKi5MHK4X+6dcc5i9HXUnT/1aqELmV0M\\nl/TIqVZ/d51tF+ZZYD1EiLq+Ak1+rI6U2N4sS3kkI7M2Fht7iqOH2wZScdNblFBw\\n3CZ9M1Mx4mZ7AuZnO1f3oVESsH/tjBRmg3AHpLoazoup9cwpQBIe061W4UFAKKpC\\nBAkOxHbF4CcXtdWK+fICNATEeg9PfRBtOFpbT94HuRsgOFobA/rWzDntUtWdgpKq\\nmc4YYUGZRdt1pu5WRKSWFGuO6xQJo303dDMA2tQgi2FR0JDCwerRGxBTc+P0Gw2m\\nFEA+H09gK5VSC2HJlyanazUekPVgWOAzI3kY/rIj2wKBgQDINaU54O74/2ZSaDJQ\\nHSk9/AXHSydFQ7IeCEUPS3itjSa3UsMhzJ9+vZMnIWYtaGfw4N22XeTAmjoeTxMk\\nSQLLfvbyjcOVK90e9PLHwzHqVntQ659OU+zPlBORhMOsmUk+uIogoQHGwbM1AxhG\\nKFSMCDvbMrnrFPUQrRGI4RbU2wKBgQC9tSR5KQZ4vbd24WYfnfX77vH1YjI5XLWP\\nJ7uZbcsilk+VDfgOg7XEcDAev6TtUyXx+izqkodfty2Fwr1UtbUtdLX0EK8iLk/T\\nhEv/BsfZ59i2ttZ7VrBXqn/1SfoAUWHdj4b6CuVDVeQ9Y3HOFoDNe9C4Nuwl02nJ\\nnzlXnBgWDwKBgBajCiV7K0n4Bqe2pEmuomUhw71+39fTCaafpL9P9zsYRJJhxzJh\\nIn+AC81W12i271mq8yaVgzHLvlqC8lUd9DTyDBXstXp+VSgU5gZ0KYandJX3rjF7\\nB8GIqpW/fyhaxI9U6jk6Oysv54VM7kewc67Jl4r3N1I/Ml5KUzs4yA4VAoGAQ+xc\\nn8jxmT+MNdNkRkO/dDHMjihXhTRNiXEXeUrXZY3d9qdmvoOoDCqDAC9r9NFFj8sc\\nU+yc7cdfVDoyoebhdOIJ19Y1bo6YZEpFD4209q9NZ7Y1OzoBr5HLeN7A1WZOHQ8r\\nq9FE3wQc0WIOuFRUT75aL+rySGTWxqrs1BJ+iT8CgYEAwFhZCj+Kh660UCrfc+nS\\nmEv7pfrPvx4TcGgWN63Qi8W6qs96UnAFPMyC0A0RC8UkcnbF/rbZTqt/Lz+R5GVp\\nXMn+jF5GMEsKWrrA1rxGo7izlEfQuaxpeSgV9bEq/9JOOzevUT2n5grra/CucOjE\\nK+IBmdDNWCDI88U4BpmBNiQ=\\n-----END PRIVATE KEY-----\\n\"," +
			//"  \"client_email\": \"firebase-adminsdk-ksbh7@mapfirebase-2e39e.iam.gserviceaccount.com\"," +
			//"  \"client_id\": \"104198640569349210638\",  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",  " +
			//"\"token_uri\": \"https://oauth2.googleapis.com/token\",  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",  " +
			//"\"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-ksbh7%40mapfirebase-2e39e.iam.gserviceaccount.com\", " +
			//"\"universe_domain\": \"googleapis.com\"\r\n}";
			//var fdb = FirestoreDb.Create("mapfirebase-2e39e", fcb.Build());
			//var res = fdb.Collection("HOh")
			//	.AddAsync(new { krokodile = "krokrokrokrokro" }).Result
			//	.GetSnapshotAsync().Result;
			if (!isKnowCurrentTheme)
			{
				if (Application.Current.Resources["Theme"] is string str)
				{
					if (str == Theme.Default.ToString())
					{ 
						_currentTheme = Theme.Default;
					}
					else if(str == Theme.Second.ToString()) 
					{
						_currentTheme = Theme.Second;
					}
				}
				else
				{
					_currentTheme = Theme.Default;
				}
				isKnowCurrentTheme = true;
			}

			return _currentTheme;
		}
		public void SetCurrentTheme(Theme theme)
		{
			// Application.Current.Resources.MergedDictionaries.Clear();
			ResourceDictionary rd;

			if (_currentTheme == Theme.Default) 
			{
				rd = new SecondTheme();
			}
			else
			{
				rd = new DefaultTheme();
			}

			foreach(string key in  rd.Keys)
			{
				Application.Current.Resources[key] = rd[key];
			}

			_currentTheme = theme;
		}
	}
}