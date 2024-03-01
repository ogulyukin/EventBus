using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class EntityButtonListener : MonoBehaviour
    {
        [SerializeField] private HeroListView heroListView;
        [SerializeField] private Button entityButton;
        [SerializeField] private EntityConfig entity;
        public Action<EntityConfig> OnTargetClicked;
        public void OnEnable()
        {
            //heroListView.OnHeroClicked += OnButtonClick;
            //heroListView.SetActive(true);
            entityButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick(HeroView obj)
        {
            OnTargetClicked?.Invoke(entity);
            Debug.Log($"Button {entity.Name} clicked");
        }

        public void OnDisable()
        {
            //heroListView.OnHeroClicked -= OnButtonClick;
            entityButton.onClick.RemoveListener(OnButtonClick);
        }
        
        private void OnButtonClick()
        {
            OnTargetClicked?.Invoke(entity);
            Debug.Log($"Button {entity.Name} clicked");
        }
    }
}
