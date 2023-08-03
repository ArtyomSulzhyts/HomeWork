using Zenject;
using UnityEngine;

namespace Pirates
{
    public class StartMenuController : MonoBehaviour
    {
        private App _app;
        
        [Inject]
        private void Construct(App app)
        {
            _app = app;
        }
        public void LoadSeaScene()
        {
            _app.LoadScene("Sea");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
