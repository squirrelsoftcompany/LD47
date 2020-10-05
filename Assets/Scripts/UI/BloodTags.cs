using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BloodTags : MonoBehaviour
    {
        public MusicSettingsSO settings;

        public Image music;
        public Image SFX;
        public Image volume;

        public Sprite spriteSFX;
        public Sprite spriteSFXMute;
        public Sprite spriteMusic;
        public Sprite spriteMusicMute;

        public Sprite spriteVolume_0;
        public Sprite spriteVolume_1;
        public Sprite spriteVolume_2;
        public Sprite spriteVolume_3;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            switch(settings.state)
            {
                case MusicSettingsSO.VolumeState.eAllActive:
                    music.sprite = spriteMusic;
                    SFX.sprite = spriteSFX;
                    break;
                case MusicSettingsSO.VolumeState.eMusicMuted:
                    music.sprite = spriteMusicMute;
                    SFX.sprite = spriteSFX;
                    break;
                case MusicSettingsSO.VolumeState.eAllMuted:
                    music.sprite = spriteMusicMute;
                    SFX.sprite = spriteSFXMute;
                    break;
            }

            if (settings.generalVolume == 0)
            {
                volume.sprite = spriteVolume_0;
            }
            else if (settings.generalVolume == 1)
            {
                volume.sprite = spriteVolume_1;
            }
            else if (settings.generalVolume == 2)
            {
                volume.sprite = spriteVolume_2;
            }
            else if (settings.generalVolume == 3)
            {
                volume.sprite = spriteVolume_3;
            }
        }
    }
}