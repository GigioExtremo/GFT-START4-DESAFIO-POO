namespace DesafioPOO.src.entities
{
    public class Wizard : Hero
    {
        public Wizard(string name, string heroClass, ushort level, uint HP, uint MP, uint maxHP, uint maxMP) : base(name, heroClass, level, HP, MP, maxHP, maxMP)
        {

        }

        public Wizard(Hero hero, string newHeroClass) : base(hero.Name, newHeroClass, hero.Level, hero.HP, hero.MP, hero.MaxHP, hero.MaxMP)
        {
            System.Console.WriteLine($"{this.Name} changed his class from {hero.HeroClass} to {newHeroClass}!\n");
        }

        public string Attack(string spellName)
        {
            return $"{this.Name} attacks with {spellName}!\n";
        }
        public string Attack(string spellName, int attackBonus = 0, string enemyName = null)
        {
            string spellAttackMessage = $"{this.Name} attacks with {spellName}";
            string bonusAttackMessage = AttackWithBonusMessage(attackBonus);
            string attackAnEnemyMessage = AttackAnEnemyMessage(enemyName);

            if (!string.IsNullOrEmpty(bonusAttackMessage) && !string.IsNullOrEmpty(attackAnEnemyMessage))
            {
                return $"{spellAttackMessage}, {bonusAttackMessage}, {attackAnEnemyMessage}!\n";
                
            }
            
            return $"{spellAttackMessage}, {bonusAttackMessage}{attackAnEnemyMessage}!\n";
        }

    }
}