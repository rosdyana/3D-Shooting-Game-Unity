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

using UnityEngine;

namespace wHiteRabbiT.Unity.Extensions
{
	public static class VectorExtensions
	{	
		public static Vector2 xx (this Vector2 v) { return new Vector2(v.x, v.x); }
		public static Vector2 yx (this Vector2 v) { return new Vector2(v.y, v.x); }
		public static Vector2 yy (this Vector2 v) { return new Vector2(v.y, v.y); }
		
		public static Vector2 xx (this Vector3 v) { return new Vector2(v.x, v.x); }
		public static Vector2 xy (this Vector3 v) { return new Vector2(v.x, v.y); }
		public static Vector2 xz (this Vector3 v) { return new Vector2(v.x, v.z); }
		public static Vector2 yx (this Vector3 v) { return new Vector2(v.y, v.x); }
		public static Vector2 yy (this Vector3 v) { return new Vector2(v.y, v.y); }
		public static Vector2 yz (this Vector3 v) { return new Vector2(v.y, v.z); }
		public static Vector2 zx (this Vector3 v) { return new Vector2(v.z, v.x); }
		public static Vector2 zy (this Vector3 v) { return new Vector2(v.z, v.y); }
		public static Vector2 zz (this Vector3 v) { return new Vector2(v.z, v.z); }
				
		
		
		public static Vector3 xxx (this Vector3 v) { return new Vector3(v.x, v.x, v.x); }
		public static Vector3 xxy (this Vector3 v) { return new Vector3(v.x, v.x, v.y); }
		public static Vector3 xxz (this Vector3 v) { return new Vector3(v.x, v.x, v.z); }
		
		public static Vector3 xyx (this Vector3 v) { return new Vector3(v.x, v.y, v.x); }
		public static Vector3 xyy (this Vector3 v) { return new Vector3(v.x, v.y, v.y); }
		public static Vector3 xyz (this Vector3 v) { return new Vector3(v.x, v.y, v.z); }
		
		public static Vector3 xzx (this Vector3 v) { return new Vector3(v.x, v.z, v.x); }
		public static Vector3 xzy (this Vector3 v) { return new Vector3(v.x, v.z, v.y); }
		public static Vector3 xzz (this Vector3 v) { return new Vector3(v.x, v.z, v.z); }
		
		
		public static Vector3 yxx (this Vector3 v) { return new Vector3(v.y, v.x, v.x); }
		public static Vector3 yxy (this Vector3 v) { return new Vector3(v.y, v.x, v.y); }
		public static Vector3 yxz (this Vector3 v) { return new Vector3(v.y, v.x, v.z); }
		
		public static Vector3 yyx (this Vector3 v) { return new Vector3(v.y, v.y, v.x); }
		public static Vector3 yyy (this Vector3 v) { return new Vector3(v.y, v.y, v.y); }
		public static Vector3 yyz (this Vector3 v) { return new Vector3(v.y, v.y, v.z); }
		
		public static Vector3 yzx (this Vector3 v) { return new Vector3(v.y, v.z, v.x); }
		public static Vector3 yzy (this Vector3 v) { return new Vector3(v.y, v.z, v.y); }
		public static Vector3 yzz (this Vector3 v) { return new Vector3(v.y, v.z, v.z); }
		
		
		public static Vector3 zxx (this Vector3 v) { return new Vector3(v.z, v.x, v.x); }
		public static Vector3 zxy (this Vector3 v) { return new Vector3(v.z, v.x, v.y); }
		public static Vector3 zxz (this Vector3 v) { return new Vector3(v.z, v.x, v.z); }
		
		public static Vector3 zyx (this Vector3 v) { return new Vector3(v.z, v.y, v.x); }
		public static Vector3 zyy (this Vector3 v) { return new Vector3(v.z, v.y, v.y); }
		public static Vector3 zyz (this Vector3 v) { return new Vector3(v.z, v.y, v.z); }
		
		public static Vector3 zzx (this Vector3 v) { return new Vector3(v.z, v.z, v.x); }
		public static Vector3 zzy (this Vector3 v) { return new Vector3(v.z, v.z, v.y); }
		public static Vector3 zzz (this Vector3 v) { return new Vector3(v.z, v.z, v.z); }

		
		
		
		public static Vector3 Frac(this Vector3 v)
		{
			return new Vector3(v.x - (int)v.x, v.y - (int)v.y, v.z - (int)v.z);
		}
		
		public static Vector3 ToVector3_0(this Vector2 v)
		{
			return new Vector4(v.x, v.y, 0);
		}
		public static Vector3 ToVector3_1(this Vector2 v)
		{
			return new Vector3(v.x, v.y, 1);
		}
		public static Vector3 ToVector3_W(this Vector2 v, float w)
		{
			return new Vector3(v.x, v.y, w);
		}
		
		public static Vector4 ToVector4_0(this Vector3 v)
		{
			return new Vector4(v.x, v.y, v.z, 0);
		}
		public static Vector4 ToVector4_1(this Vector3 v)
		{
			return new Vector4(v.x, v.y, v.z, 1);
		}
		public static Vector4 ToVector4_W(this Vector3 v, float w)
		{
			return new Vector4(v.x, v.y, v.z, w);
		}
		
		public static Vector3 ToVector3(this Vector4 v)
		{
			return new Vector3(v.x, v.y, v.z);
		}
		
		public static Vector2 ToVector2(this Vector4 v)
		{
			return new Vector2(v.x, v.y);
		}
		
		public static Vector2 ToVector2(this Vector3 v)
		{
			return new Vector2(v.x, v.y);
		}
		
		public static Vector2 Multiply(this Vector2 v0, Vector2 v1)
		{
			return new Vector2(v0.x*v1.x, v0.y*v1.y);
		}
		public static Vector3 Multiply(this Vector3 v0, Vector3 v1)
		{
			return new Vector3(v0.x*v1.x, v0.y*v1.y, v0.z*v1.z);
		}
		public static Vector4 Multiply(this Vector4 v0, Vector4 v1)
		{
			return new Vector4(v0.x*v1.x, v0.y*v1.y, v0.z*v1.z, v0.w*v1.w);
		}
		
		public static Vector2 Divide(this Vector2 v0, Vector2 v1)
		{
			return new Vector2(v0.x/v1.x, v0.y/v1.y);
		}
		public static Vector3 Divide(this Vector3 v0, Vector3 v1)
		{
			return new Vector3(v0.x/v1.x, v0.y/v1.y, v0.z/v1.z);
		}
		public static Vector4 Divide(this Vector4 v0, Vector4 v1)
		{
			return new Vector4(v0.x/v1.x, v0.y/v1.y, v0.z/v1.z, v0.w/v1.w);
		}
		
		public static Vector2 Add(this Vector2 v, float f) { return new Vector2(v.x + f, v.y + f); }
		public static Vector3 Add(this Vector3 v, float f) { return new Vector3(v.x + f, v.y + f, v.z + f); }
		public static Vector4 Add(this Vector4 v, float f) { return new Vector4(v.x + f, v.y + f, v.z + f, v.w + f); }
		
		public static Vector2 Abs(this Vector2 v) { return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y)); }
		public static Vector3 Abs(this Vector3 v) { return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z)); }
		public static Vector4 Abs(this Vector4 v) { return new Vector4(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z), Mathf.Abs(v.w)); }
		
		public static Vector3 ToCubeMapUVFace(this Vector3 v)
		{
			int face;
			float m;
			float s;
			float t;
			
			if((Mathf.Abs(v.x) > Mathf.Abs(v.y)) && (Mathf.Abs(v.x) > Mathf.Abs(v.z)))
			{
				if (v.x>=0)        
					{face = 0; m = v.x; s = -v.z; t = -v.y;}       
				else
					{face = 1; m = -v.x; s = v.z; t = -v.y;}
			}
			else  if((Mathf.Abs(v.y) > Mathf.Abs(v.x)) && (Mathf.Abs(v.y) > Mathf.Abs(v.z)))
			{
				if (v.y>=0)
					{face = 2; m = v.y; s = v.x; t = v.z;}     
				else
					{face = 3; m = -v.y; s = v.x; t = -v.z;}
			}
			else
			{
				if (v.z>=0)
					{face = 4; m = v.z; s = v.x; t = -v.y;}        
				else
					{face = 5; m = -v.z; s = -v.x; t = -v.y;}
			}
			
			float uc = m==0 ? 0 : (s/m + 1.0f) / 2.0f;
			float vc = m==0 ? 0 : (t/m + 1.0f) / 2.0f;
			
			return new Vector3(uc, vc, face);
		}
		
//		public static bool Approximately(this Vector2 v, Vector2 v1)
//		{
//			return Mathf.Approximately(v.x, v1.x) &&
//				   Mathf.Approximately(v.y, v1.y);
//		}
//		public static bool Approximately(this Vector3 v, Vector3 v1)
//		{
//			return Mathf.Approximately(v.x, v1.x) &&
//				   Mathf.Approximately(v.y, v1.y) &&
//				   Mathf.Approximately(v.z, v1.z);
//		}
//		public static bool Approximately(this Vector4 v, Vector4 v1)
//		{
//			return Mathf.Approximately(v.x, v1.x) &&
//				   Mathf.Approximately(v.y, v1.y) &&
//				   Mathf.Approximately(v.z, v1.z) &&
//				   Mathf.Approximately(v.w, v1.w);
//		}
		
		public static Color ToColor(this Vector2 v) { return new Color(v.x, v.y, 0, 0); }
		public static Color ToColor(this Vector3 v) { return new Color(v.x, v.y, v.z, 0); }
		public static Color ToColor(this Vector4 v) { return new Color(v.x, v.y, v.z, v.w); }
	}
	
	public static class QuaternionExtensions
	{
//		public static bool Approximately(this Quaternion q, Quaternion q1)
//		{
//			return Mathf.Approximately(q.x, q1.x) &&
//				   Mathf.Approximately(q.y, q1.y) &&
//				   Mathf.Approximately(q.z, q1.z) &&
//				   Mathf.Approximately(q.w, q1.w);
//		}
	}
	
	public static class ColorExtensions
	{
		public static Vector4 ToVector4(this Color c)
		{
			return new Vector4(c.r, c.g, c.b, c.a);
		}
		
		public static float Sum(this Color c)
		{
			return c.r + c.g + c.b + c.a;
		}
		
		public static Color Alpha(this Color c, float alpha)
		{
			return new Color(c.r, c.g, c.b, alpha);
		}
	}
}
