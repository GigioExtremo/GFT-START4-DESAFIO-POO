namespace DesafioPOO.src.entities
{
    public class Knight : Hero
    {
        public Knight(string name, string heroClass, ushort level, uint HP, uint MP, uint maxHP, uint maxMP) : base(name, heroClass, level, HP, MP, maxHP, maxMP)
        {

        }

        public Knight(Hero hero, string newHeroClass) : base(hero.Name, newHeroClass, hero.Level, hero.HP, hero.MP, hero.MaxHP, hero.MaxMP)
        {
            System.Console.WriteLine($"{this.Name} changed his class from {hero.HeroClass} to {newHeroClass}!\n");
        }        
        
        public override string Attack()
        {
            return $"{this.Name} attacks with a sword!\n";
        }

        public override string Attack(int attackBonus = 0, string enemyName = null)
        {
            string bonusAttackMessage = AttackWithBonusMessage(attackBonus);
            string attackAnEnemyMessage = AttackAnEnemyMessage(enemyName);

            if (!string.IsNullOrEmpty(bonusAttackMessage) && !string.IsNullOrEmpty(attackAnEnemyMessage))
            {
                return $"{this.Name} with a sword, {bonusAttackMessage},{attackAnEnemyMessage}!\n";
                
            }
            
            return $"{this.Name} attacks with a sword, {bonusAttackMessage}{attackAnEnemyMessage}!\n";
        }
    }
}