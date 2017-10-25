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

//using UnityEditor;

using UnityEngine;
using wHiteRabbiT.Unity.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace wHiteRabbiT.Unity.UI
{
	public class GUIHelper
	{
		protected static Texture2D _wHiteTex;
		public static Texture2D wHiteTex
		{
			get {
//#if UNITY_EDITOR
//				return UnityEditor.EditorGUIUtility.whiteTexture; // Bad texture ! 4x4
//#else
				if (_wHiteTex == null)
				{
					_wHiteTex = new Texture2D(1,1,TextureFormat.ARGB32, false);
					_wHiteTex.SetPixel(0,0,new Color(1,1,1,1));
					_wHiteTex.Apply();
				}
				
				return _wHiteTex;
//#endif
			}
		}
		
		public static void DrawRectFillAlpha(Rect rect, Color color, float alpha)
		{
			Color guiColor = GUI.color;
			
			GUI.color = color.Alpha(alpha);
			GUI.DrawTexture(rect, wHiteTex);
			
			GUI.color = color.Alpha(1);
			GUI.DrawTexture(new Rect(rect.x, rect.y, rect.width, 1+0*rect.height), wHiteTex);
			GUI.DrawTexture(new Rect(rect.x, rect.y, 1+0*rect.width, rect.height), wHiteTex);
			GUI.DrawTexture(new Rect(rect.x + rect.width, rect.y + rect.height, -rect.width, -1+0*rect.height), wHiteTex);
			GUI.DrawTexture(new Rect(rect.x + rect.width, rect.y + rect.height, -1+0*rect.width, -rect.height), wHiteTex);
			
			GUI.color = guiColor;
		}
		
		public static void DrawRectFillPCAlpha(Rect rect, Color color, float alpha, float pc)
		{
			Color guiColor = GUI.color;
			
			float w = rect.width * pc;
			float iw = rect.width - w;
			
			GUI.color = color.Alpha(alpha);
			GUI.DrawTexture(new Rect(rect.x + w, rect.y, iw, rect.height), wHiteTex);
			
			GUI.color = color.Alpha(1);
			
			GUI.DrawTexture(new Rect(rect.x, rect.y, w, rect.height), wHiteTex);
			
			GUI.DrawTexture(new Rect(rect.x, rect.y, rect.width, 1+0*rect.height), wHiteTex);
			GUI.DrawTexture(new Rect(rect.x, rect.y, 1+0*rect.width, rect.height), wHiteTex);
			GUI.DrawTexture(new Rect(rect.x + rect.width, rect.y + rect.height, -rect.width, -1+0*rect.height), wHiteTex);
			GUI.DrawTexture(new Rect(rect.x + rect.width, rect.y + rect.height, -1+0*rect.width, -rect.height), wHiteTex);
			
			GUI.color = guiColor;
		}
		
		public static void DrawCenteredRect3D(Vector3 p, Vector2 size, Color color) { DrawCenteredRect3D(p, size, color, Camera.main); }
		public static void DrawCenteredRect3D(Vector3 p, Vector2 size, Color color, Camera camera)
		{
			if (camera == null)
				return;
			
			GUI.color = color;
			
			Vector3 p2D = camera.WorldToScreenPoint(p);
			if (p2D.z < 0)
				return;
			
			GUI.DrawTexture(new Rect(p2D.x - size.x*0.5f,
									 Screen.height - p2D.y - size.y*0.5f,
									 size.x, size.y), wHiteTex);
		}
		
		public static void Label3D(Transform transform, string str) { Label3D(transform, str, Vector2.zero, Vector2.zero, Camera.current); }
		public static void Label3D(Transform transform, string str, Vector2 decal) { Label3D(transform, str, decal, Vector2.zero, Camera.current); }
		public static void Label3D(Transform transform, string str, Vector2 decal, Vector2 size) { Label3D(transform, str, decal, size, Camera.current); }
		public static void Label3D(Transform transform, string str, Vector2 decal, Vector2 size, Camera cam)
		{
			if (cam == null)
				return;
			
			GUIStyle gs = new GUIStyle(GUIStyle.none);
			gs.normal.textColor = Color.white;
			gs.clipping = TextClipping.Overflow;
			gs.alignment = TextAnchor.MiddleCenter;
			
			Vector3 p2D = cam.WorldToScreenPoint(transform.position);
			if (p2D.z > 0)
			{
				GUI.Label(new Rect(p2D.x + decal.x, Screen.height - p2D.y - decal.y, size.x, size.y), str, gs);
			}		
		}
		
		public static void Hyperlink(string Label, string Url, GUIStyle gsBase)
		{
			if (GUILayout.Button(Label, gsBase))
				Application.OpenURL(Url);
			
			Rect r = GUILayoutUtility.GetLastRect();

			float mw, Mw;
			float h = gsBase.CalcHeight(new GUIContent(Label), r.width) - gsBase.padding.top - gsBase.padding.bottom;
			gsBase.CalcMinMaxWidth(new GUIContent(Label), out mw, out Mw);
			
			//Vector2 v = gsBase.CalcSize(new GUIContent(Label));
			
			Rect nr = new Rect(
				r.x + gsBase.padding.left,
				r.y + gsBase.padding.top + h,
				Mw - gsBase.padding.left - gsBase.padding.right,
				1);
			
			Color oldC = GUI.color;
			GUI.color = gsBase.normal.textColor;
			
			GUI.DrawTexture(nr, wHiteTex);
			
			GUI.color = oldC;

#if UNITY_EDITOR
			UnityEditor.EditorGUIUtility.AddCursorRect(r, UnityEditor.MouseCursor.Link);
#endif
		}
		
		public static void Separator()
		{
			GUILayout.BeginHorizontal();
			GUILayout.EndHorizontal();
			
			Rect R = GUILayoutUtility.GetLastRect();
			
			GUILayout.Space(10);
			GUI.DrawTexture(new Rect(R.x, R.y + R.height + 5, R.width, 1), wHiteTex);
		}

	}
}