/* File Description
 * Original Works/Author: Zachariah Brown
 * Other Contributors: None
 * Author Website: http://www.zbrown.net/projects
 * License: MIT
*/

using System;
using System.Diagnostics;

namespace SFGL.Time
{
    public class Clock
    {
        #region Variables
		private Stopwatch _timer = Stopwatch.StartNew();
        #endregion

        #region Properties
		public GameTime ElapsedTime
        {
			get { return GameTime.FromTicks(_timer.ElapsedTicks); }
        }
        #endregion

        #region Functions
		public GameTime Restart()
        {
			GameTime tm = GameTime.FromTicks(_timer.ElapsedTicks);
            _timer.Reset();
            _timer.Start();
            return tm;
        }
        #endregion
    }
}