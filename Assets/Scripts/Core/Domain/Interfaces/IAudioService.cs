public interface IAudioService
{
    void PlayClick();
    void PlayGameBGM();
    void PlayMainMenuBGM();
    void PlayGameOverBGM();

    void SetBGMVolume(float value);
    void SetSFXVolume(float value);

    float GetBGMVolume();
    float GetSFXVolume();
}