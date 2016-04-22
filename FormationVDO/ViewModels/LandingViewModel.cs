using System;
using System.Windows.Input;

namespace FormationVDO
{
	public class LandingViewModel
	{
		public string Message {
			get;
			set;
		}

		public string ContinueMsg {
			get;
			set;
		
		}

		public LandingViewModel ()
		{
			this.Message = "Bienvenue à Paris !";
			this.ContinueMsg = "Continue";
		}
	}
}

