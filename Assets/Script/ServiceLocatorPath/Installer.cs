using Game.VisorDeDialogosSystem;
using SystemOfExtras.SavedData;
using UnityEngine;

namespace SystemOfExtras
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private DialogSystem dialogSystem;
        [SerializeField] private LoadSceneService ladSceneM;
        private void Awake()
        {
            if (FindObjectsOfType<Installer>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            ServiceLocator.Instance.RegisterService<IDialogSystem>(dialogSystem);
            ServiceLocator.Instance.RegisterService<ILoadScene>(ladSceneM);
            ServiceLocator.Instance.RegisterService<IServiceOfMissions>(new ServiceOfMissions());
            ServiceLocator.Instance.RegisterService<ISaveData>(new SaveData());
            DontDestroyOnLoad(gameObject);
        }
    }
}