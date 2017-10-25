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

using UnityEditor;

using UnityEngine;
using System;
using System.Xml;
using wHiteRabbiT.Unity.Util;
using wHiteRabbiT.Unity.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace wHiteRabbiT.UnityEditor
{
	public class wHiteRabbiTEW : EditorWindow 
	{	
		protected Texture2D logo2D;
		protected Texture2D Logo2D
		{
			set { logo2D = value; }
			get {
				if (logo2D == null)
				{
					logo2D = Logo.Texture;
					
					WWW www = new WWW("http://www.whiterabbit-studio.com/sites/all/themes/zen_whiterabbit/images/Logo.png");
					ContinuationManager.Add(() => www.isDone, () =>
					{
						if (!string.IsNullOrEmpty(www.error) || www.texture == null)
						{
							Debug.LogWarning("Failed to connect to the website.");
							return;
						}
						
						logo2D = www.texture;
						
						this.Repaint();
					});
				}
				
				return logo2D;
			}
		}
		
		public class NewsXml
		{
			public string newsTitle;
			public string newsUrl;
			public string content;
		}
		protected List<NewsXml> newsXml;
		
		public string news;
		protected void UpdateNews()
		{
			if (news == null)
			{
				news = "Updating news...";
				
				WWW www = new WWW("http://www.whiterabbit-studio.com/feed");
				ContinuationManager.Add(() => www.isDone, () =>
				{
					if (!string.IsNullOrEmpty(www.error))
					{
						news = "Failed to connect to the website.";
						return;
					}
					string xml = www.text;//.Replace("&&", "");
					
					try
					{
						XmlDocument doc = new XmlDocument();
						doc.LoadXml(xml);
					
						XmlNodeList xnl = doc.GetElementsByTagName("item");
						newsXml = new List<NewsXml>();
						
						foreach(XmlNode xn in xnl)
						{
							NewsXml nx = new NewsXml();
							newsXml.Add(nx);
							
					        foreach(XmlNode xnc in xn.ChildNodes)
					        {
					            switch(xnc.Name)
					            {
					                case "title":
										nx.newsTitle = xnc.InnerText;
										break;
									
					                case "link":
										nx.newsUrl = xnc.InnerText;
										break;
									
					                case "description":
				                        nx.content = xnc.InnerText;
										nx.content = Regex.Replace(nx.content, @"<[^>]*>", String.Empty);
										nx.content = nx.content.Replace("<br />", "\n");
					                    break;
					            }								
					        }
						}
					}
					catch(Exception e)
					{
						news = e.Message + "\n\n" + news;//"Error in parsing the website.";
					}
					
					this.Repaint();
				});				
			}
		}
		
		public virtual void OnDestroy()
		{
			news = null;
		}
		
		protected GUIStyle styleNone;
		protected GUIStyle StyleNone
		{
			get { return styleNone == null ? (styleNone = new GUIStyle(GUIStyle.none) {padding = new RectOffset(10, 10, 10, 10)}) : styleNone; }
		}
		protected GUIStyle styleBasic;
		protected GUIStyle StyleBasic
		{
			get {
				if (styleBasic == null)
				{
					styleBasic = new GUIStyle(StyleNone) {wordWrap = true, alignment = TextAnchor.UpperLeft};
				    Color c = Color.white;
					c.a = 0.75f;
					styleBasic.normal.textColor = c;
				}
				return styleBasic;
			}			
		}
		
		protected GUIStyle styleURL;
		protected GUIStyle StyleURL
		{
			get { return styleURL == null ? (styleURL = StyleColor(new Color(63/255.0f, 154/255.0f, 1, 1))) : styleURL; }
		}
		
		protected GUIStyle StyleColor(Color c)
		{
			GUIStyle gs = new GUIStyle(StyleBasic) {normal = {textColor = c}};
		    return gs;
			
		}
		
		protected bool bPerformUndo;
		protected static Vector2 sV;
		public virtual void OnGUI()
		{
			#region Intro
			EditorGUILayout.BeginHorizontal(GUILayout.Height(Logo2D.height + 20));
			
			GUILayout.Box(Logo2D, StyleNone);
			
			sV = EditorGUILayout.BeginScrollView(sV, false, true);
			
			GUIHelper.Hyperlink("wHiteRabbiT sTudio site", "http://www.whiterabbit-studio.com", StyleURL);
			
			UpdateNews();
			
			if (newsXml == null)
			{
				GUILayout.Label(news, StyleBasic, GUILayout.ExpandWidth(true));
			}
			else
			{
				foreach(var nx in newsXml)
				{			
					if (!string.IsNullOrEmpty(nx.newsTitle) && !string.IsNullOrEmpty(nx.newsUrl))
						GUIHelper.Hyperlink(nx.newsTitle, nx.newsUrl, StyleURL);
				
					GUILayout.Label(nx.content, StyleBasic, GUILayout.ExpandWidth(true));
				}
			}
			
			EditorGUILayout.EndScrollView();
			
			EditorGUILayout.EndHorizontal();
			#endregion
			
			GUIHelper.Separator();	
			
			if (Event.current.type == EventType.ValidateCommand && Event.current.commandName == "UndoRedoPerformed")
			{
  				// Undo/redo was performed. Repaint.
  				Repaint();
			}
		}	
	}
}