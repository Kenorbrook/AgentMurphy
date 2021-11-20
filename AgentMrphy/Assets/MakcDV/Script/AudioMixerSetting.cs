using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[CreateAssetMenu(menuName ="Mixer")]
public class AudioMixerSetting : ScriptableObject
{
    [SerializeField] private float _offValue = -50;
    [SerializeField] private string _key;
    [SerializeField] private string _nameVariable;
    [SerializeField] private AudioMixer _mixer;
    
    private int mode;

    public AudioMixer Mixer => _mixer;
    public bool LoadSetting()
    {
        if (!PlayerPrefs.HasKey(_key))
            return false;
        _mixer.SetFloat(_nameVariable, PlayerPrefs.GetFloat(_key));
        return true;
    }

    public void OnSetSound(Slider slider)
    {
        float value = 1 - slider.value;
        Save(_key, _offValue * value);
        value = 1 - slider.value * mode;
        _mixer.SetFloat(_nameVariable, _offValue * value);
    }
    public void OnChooseMode(bool isMode)
    {
        float value = _offValue;
        if (!isMode)
        {
            mode = 0;
            float curretVolume;
            _mixer.GetFloat(_nameVariable, out curretVolume);
            Save(_key, curretVolume);
        }
        else
        {
            mode = 1;
            value = GetValue(_key);
        }
        _mixer.SetFloat(_nameVariable, value);
    }
    private float GetValue(string key)
    {
        if(PlayerPrefs.HasKey(key))
           return PlayerPrefs.GetFloat(key);
        return _offValue;
    }
    private void Save(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
}
