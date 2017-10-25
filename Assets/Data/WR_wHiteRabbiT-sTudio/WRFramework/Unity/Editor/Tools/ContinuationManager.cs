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
using System;
using System.Collections.Generic;
using System.Linq;

namespace wHiteRabbiT.UnityEditor
{
	internal static class ContinuationManager
	{
		#region Singleton
	#if SINGLETON
		protected static ContinuationManager instance;
		public static ContinuationManager Instance
		{
			get {
				if (instance == null)
				{
					instance = (ContinuationManager)FindObjectOfType(typeof(ContinuationManager));
					
					if (instance == null)
						instance = new GameObject("Singleton - ContinuationManager").AddComponent<ContinuationManager>();
				}
				return instance;
			}
		}
	#endif
		#endregion
		
	    private class Job
	    {
	        public Job(Func<bool> completed, Action continueWith)
	        {
	            Completed = completed;
	            ContinueWith = continueWith;
	        }
	        public Func<bool> Completed { get; private set; }
	        public Action ContinueWith { get; private set; }
	    }
	 
	    private static readonly List<Job> jobs = new List<Job>();
	 
	    public static void Add(Func<bool> completed, Action continueWith)
	    {
	        if (!jobs.Any()) EditorApplication.update += Update;
	        jobs.Add(new Job(completed, continueWith));
	    }
	 
	    private static void Update()
	    {
	        for (int i = 0; i >= 0; --i)
	        {
	            var jobIt = jobs[i];
	            if (jobIt.Completed())
	            {
	                jobIt.ContinueWith();
	                jobs.RemoveAt(i);
	            }
	        }
	        if (!jobs.Any()) EditorApplication.update -= Update;
	    }
	}
}