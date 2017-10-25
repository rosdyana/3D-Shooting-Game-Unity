// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM //
//                                                              //
// Copyright 2013 wHiteRabbiT sTudio whiterabbitstudio@live.fr  //
//                                                              //
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY    //
// KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE   //
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR      //
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS   //
// OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR     //
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR   //
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE    //
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.       //
//                                                              //
// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM //

//#define SINGLETON

using UnityEditor;

using UnityEngine;
using wHiteRabbiT.Unity.UI;
using System.Xml;
using System;
using System.Text.RegularExpressions;

namespace wHiteRabbiT.UnityEditor
{
	public class AboutEW : wHiteRabbiTEW
	{
		[MenuItem ("Window/wHiteRabbiT sTudio/About")]
		public static void CreateAboutEW()
		{
			AboutEW wnd = GetWindow<AboutEW>();
			wnd.title = "wHiteRabbiT sTudio - About";
		}
		
		#region Destroy
		public override void OnDestroy()
		{
		}
		#endregion
		
		protected string content;
		protected string Content
		{
			get {
				if (string.IsNullOrEmpty(content))
				{
					content = "Updating ...";
					
					WWW www = new WWW("http://www.whiterabbit-studio.com/aboutRss");
					ContinuationManager.Add(() => www.isDone, () =>
					{
						if (!string.IsNullOrEmpty(www.error))
						{
							content = "Failed to connect to the website.";
							return;
						}
						string xml = www.text;
						
						try
						{
							XmlDocument doc = new XmlDocument();
							doc.LoadXml(xml);
						
							content = "";
							
							XmlNodeList xnl = doc.GetElementsByTagName("item");
							
							foreach(XmlNode xn in xnl)
							{
						        foreach(XmlNode xnc in xn.ChildNodes)
						        {
						            switch(xnc.Name)
						            {
						                case "description":
					                        content = xnc.InnerText;
											content = Regex.Replace(content, @"<[^>]*>", String.Empty);
											content = content.Replace("<br />", "\n");
						                    break;
						            }								
						        }
							}
						}
						catch(Exception e)
						{
							content = e.Message + "\n\n" + content;//"Error in parsing the website.";
						}
						
						this.Repaint();
					});				
				}
				return content;
			}
		}
		
		public override void OnGUI ()
		{
			base.OnGUI();

			GUILayout.Label(Content, StyleBasic, GUILayout.ExpandWidth(true));
			
			GUIHelper.Hyperlink("contact@whiterabbit-studio.com", "mailto:contact@whiterabbit-studio.com", StyleURL);

		}
	}
}
// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM //
//                                                              //
// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMI7OMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM7. IMMMMMMMMMMMI7IMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM7.?.7MMMMMMMM7  .7MMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM8....7MMMMMI...I7MMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMM:...=MMMM7 ...7MMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMM7=...ZMMI....+MMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMM77...IM7....:DMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMN?...77 ...=DMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMM7...I?...?MMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMM8.== null ?=~I?7NMMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMM7.?I ....7MMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMN,?7$?... IMMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM7..........=DMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM,........? .7MMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM7........=..7MMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMM=.?III?I:,7MMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM7...........OMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMI...........NMMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMM7............7MMMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMM:...?.........7MMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMM~...I..........$MMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMI...I..........IMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMI...I ..........IMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMM7 ..+?.......... 7MMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM7..?,...I.......7MMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMI .I...?.........7MMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM8 7..= ..I.......7MMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMM87 .7............,MMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMM+.I..............DMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMM8....... ........$MMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMO~......,.......=MMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMM7......7.......$MMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMM777II .... =.....7MMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMM$.=I7777777I...?=IMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMI7I$8MMMMMMMMMMMMMMMMMMMMMMMMM //
// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM //
//                                                              //
// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM //
