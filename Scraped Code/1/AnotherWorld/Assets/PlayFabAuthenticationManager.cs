using System;
using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;

namespace PlayFab
{
    public class PlayFabAuthenticationManager : MonoBehaviour
    {
        public enum LinkTypes
        {
            PlayFab = 0,
            Facebook = 1,
            Google = 2,
            Steam = 3,
            Kongregate = 4,
            Custom = 5,
            Ios,
            Android,
            None = -1
        }

        public string TitleId;
        public WebRequestType PlayFabRequestType = WebRequestType.HttpWebRequest;
        public bool TestMode = true;
        public bool ShowDebug = true;

        public static UserAccountInfo AccountInfo;
        public static string PlatFabId = string.Empty;
        private static string _CustomGuid = string.Empty;
        private static LinkTypes _linkType = LinkTypes.None;
        private static bool _isRegistered;


        public static PlayFabAuthenticationManager Instance { get; private set; }

        #region Events

        public delegate void PlatformCheckCompleteHandler(LinkTypes linkType);
        public static event PlatformCheckCompleteHandler OnPlatformCheckComplete;

        public delegate void PlayFabReturnPlayerCheckCompleteHandler(LinkTypes linkType);
        public static event PlayFabReturnPlayerCheckCompleteHandler OnReturnPlayerCheckComplete;

        public delegate void PlayFabAuthenticationCompleteHandler(LinkTypes linktype, LoginResult result);
        public static event PlayFabAuthenticationCompleteHandler OnPlayFabAuthComplete;

        public delegate void PlayFabAuthenticationErrorHandler(LinkTypes linktype, PlayFabError error);
        public static event PlayFabAuthenticationCompleteHandler OnPlayFabAuthError;

        #endregion

        private void Awake()
        {
            //Singleton behavior
            Instance = this;
            //If test mode, then create a mini guid that will append to all player to always prefs.
            _CustomGuid = TestMode ? Guid.NewGuid().ToString().Substring(0, 7) : string.Empty;
        }

        // Use this for initialization
        void Start()
        {
            if(TitleId == null || TitleId.Equals(string.Empty))
            {
                Debug.LogError("To use PlayFab, you must populate your TitleID on the PlayFabAuthenticationManager GameObject.");
                return;
            }

            PlayFabSettings.TitleId = TitleId;
            //Check to see if the player has been registered before.
            _isRegistered = PlayerPrefs.HasKey(string.Format("{0}_PlayFabIsRegistered", _CustomGuid));

            if (!_isRegistered)
            {
            //    CheckPlatform(); // some method not declared yet
            }
            else
            {
                //Okay, check for a stored login type
                _linkType = !PlayerPrefs.HasKey(string.Format("{0}_PlayFabLinkType", _CustomGuid))
                    ? LinkTypes.None
                    : (LinkTypes)PlayerPrefs.GetInt(string.Format("{0}_PlayFabLinkType", _CustomGuid));
                if(OnReturnPlayerCheckComplete != null)
                {
                    OnReturnPlayerCheckComplete(_linkType);
                }
            }
        }

        public static void LoginByLinkType()
        {
            //Check if we are previously registered. (Note: we assigned this variable in awake)
            if (!_isRegistered)
            {
                //Okay, check for a stored login type
                _linkType = !PlayerPrefs.HasKey(string.Format("{0}_PlayFabLinkType", _CustomGuid))
                    ? LinkTypes.None
                    : (LinkTypes)PlayerPrefs.GetInt(string.Format("{0}_PlayFabLinkType", _CustomGuid));

            //    Instance.LogintoPlayFab(_linkType); // another missing method

            }
        } 
        // Update is called once per frame
        void Update()
        {

        }
    }
}