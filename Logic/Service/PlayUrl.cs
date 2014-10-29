using System;
using System.Collections.Generic;
using System.IO;

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace Logic.Service
{
    public class PlayUrl
    {
        public void Play()
        {
            WMPLib.WindowsMediaPlayer axMusicPlayer = new WMPLib.WindowsMediaPlayer();


            string path = Path.GetFullPath(@"http://traffic.libsyn.com/sweclockers/sweclockers_podcast_20140418.mp3");

            axMusicPlayer.URL = path;

            axMusicPlayer.settings.setMode("loop", true);

            axMusicPlayer.controls.play();
        }
    }
}
