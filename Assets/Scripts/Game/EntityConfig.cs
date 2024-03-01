using Game.HeroesAbilities;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;

namespace Game
{
    public class EntityConfig : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int damage;
        [SerializeField] private bool team;
        [SerializeField] private new string name;
        [SerializeField] private HeroView view;
        [ShowInInspector] private int _currentHealth;
        
        [ShowInInspector] private bool _skipTurn;
        [ShowInInspector] private bool _cantStrikeBack;
        [ShowInInspector] private bool _skipAttackTargeting;

        [SerializeReference] private BaseAbility _globalAbility;
        [SerializeReference] private BaseAbility _beforeAttackAbility;
        [SerializeReference] private BaseAbility _afterAttackAbility;
        [SerializeReference] private BaseAbility _endTurnAbility;
        [SerializeReference] private BaseAbility _afterStrikeBackAbility;
        
        public bool SkipAttackTargeting
        {
            get => _skipAttackTargeting;
            set => _skipAttackTargeting = value;
        }
        public bool SkipTurn
        {
            get => _skipTurn;
            set => _skipTurn = value;
        }

        public bool CantStrikeBack
        {
            get => _cantStrikeBack;
            set => _cantStrikeBack = value;
        }

        private void Start()
        {
            _currentHealth = Health;
        }

        public int Health
        {
            get => health;
            set => health = value;
        }

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        public bool Team
        {
            get => team;
            set => team = value;
        }
        
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public bool IsDead { get; set; }
        
        public string Name => name;
        
        public HeroView View => view;

        public bool TryGetGlobalAbility(out BaseAbility ability)
        {
            ability = _globalAbility;
            if (_globalAbility != null) return true;
            return false;
        }
        
        public bool TryGetBeforeAttackAbility(out BaseAbility ability)
        {
            ability = _beforeAttackAbility;
            if (_beforeAttackAbility != null) return true;
            return false;
        }
        
        public bool TryGetAfterAttackAbility(out BaseAbility ability)
        {
            ability = _afterAttackAbility;
            if (_afterAttackAbility != null) return true;
            return false;
        }
        
        public bool TryGetEndTurnAbility(out BaseAbility ability)
        {
            ability = _endTurnAbility;
            if (_endTurnAbility != null) return true;
            return false;
        }
        
        public bool TryGetAfterStrikeBackAbility(out BaseAbility ability)
        {
            ability = _afterStrikeBackAbility;
            if (_afterStrikeBackAbility != null) return true;
            return false;
        }
    }
}
