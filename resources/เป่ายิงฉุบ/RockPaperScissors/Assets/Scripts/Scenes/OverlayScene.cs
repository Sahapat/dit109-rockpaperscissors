using Cysharp.Threading.Tasks;
using UnityEngine;

namespace RockPaperScissors
{
    public class OverlayScene : MonoBehaviour
    {
        [SerializeField]
        GameObject _LoadingObj;

        Main Main => Main.Instance;
        UserStore UserStore => UserStore.Instance;
        RoomStore RoomStore => RoomStore.Instance;

        void Update()
        {
            if (Main.isLoading && !_LoadingObj.activeSelf)
            {
                _LoadingObj.SetActive(true);
            }
            else if (!Main.isLoading && _LoadingObj.activeSelf)
            {
                _LoadingObj.SetActive(false);
            }
        }

        public void RefreshAll()
        {
            UserStore.GetAllUsers().Forget();
            RoomStore.FetchRoomList().Forget();

            if (RoomStore.CurrentRoom != null && RoomStore.CurrentRoom.ID != null && RoomStore.CurrentRoom.ID != "")
            {
                RoomStore.GetRoomById(RoomStore.CurrentRoom.ID).Forget();
            }
        }

        public void BackLogin()
        {
            Main.UnloadAllScenes().Forget();
            Main.LoadSceneIfNotPresent("Login").Forget();
        }
    }
}
