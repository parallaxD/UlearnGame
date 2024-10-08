﻿using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public static class SoundManager
    {
        public static bool IsMusicOn { get; private set; }
        public static bool IsSoundsOn { get; private set; }
        private static Song _music;

        private static SoundEffect _playerAttackSound;
        private static SoundEffect _demonDieSound;
        private static SoundEffect _chortDieSound;

        public static void Initialize()
        {
            _demonDieSound = Globals.Content.Load<SoundEffect>("DemonDieSound");
            _playerAttackSound = Globals.Content.Load<SoundEffect>("playerAttackSound");
            _chortDieSound = Globals.Content.Load<SoundEffect>("chortDieSound");
            _music = Globals.Content.Load<Song>("gameMusic");


            IsMusicOn = true;
            IsSoundsOn = true;

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
            MediaPlayer.Play(_music);
        }

        public static void PlayAttackSound()
        {
            if (!IsSoundsOn) return;
            _playerAttackSound.Play(0.2f, 0, 0);
        }
        public static void PlayDemonDieSound()
        {
            if (!IsSoundsOn) return;
            _demonDieSound.Play(0.5f, 0, 0);
        }
        public static void PlayChortDieSound()
        {
            if (!IsSoundsOn) return;
            _chortDieSound.Play(0.2f, 0, 0);
        }
    }
}
