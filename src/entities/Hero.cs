using System;

namespace DesafioPOO.src.entities
{
    public abstract class Hero
    {
        public string Name {get; protected set;}
        public string HeroClass {get; protected set;}
        public ushort Level {get; protected set;}
        public uint MaxHP {get; protected set;}
        public uint HP {get; protected set;}
        public uint MaxMP {get; protected set;}
        public uint MP {get; protected set;}

        public Hero(string name, string heroClass, ushort level, uint HP, uint MP, uint maxHP, uint maxMP)
        {
            this.Name = name;
            this.HeroClass = heroClass;
            this.Level = level;
            this.MaxHP = maxHP;
            this.HP = (HP > maxHP)? maxHP : HP;
            this.MaxMP = maxMP;
            this.MP = (MP > maxMP)? maxMP : MP;
        }

        public void RenameHero(string newName) 
        {
            if (string.IsNullOrEmpty(newName))
                Console.WriteLine("A hero can't have a empty name!\n");
            this.Name = newName;
        }
        // Method to alter the hero HP if him takes damage (negative changePoints) or get healed (positive changePoints)
        public void HPChange(int changePoints) 
        {
            if (this.HP == this.MaxHP || changePoints == 0)
                Console.WriteLine($"{this.Name} continues with the same HP.\n");
            
            else
            {
                
                if (changePoints > 0)
                {
                    this.HP += (uint) changePoints;
                    if  (this.HP == changePoints)
                    {
                        Console.Write($"{this.Name} revived");
                        if (changePoints >= this.MaxHP) 
                        {
                            this.HP = this.MaxHP;
                            Console.WriteLine(" to full HP!\n");
                        }
                        else
                            Console.WriteLine($", now having {this.HP} HP!\n");
                    }
                        
                    else if (this.HP >= this.MaxHP) 
                    {
                        this.HP = this.MaxHP;
                        Console.WriteLine($"{this.Name} just got restored his HP to the fullest!\n");
                    }
                    else
                        Console.WriteLine($"{this.Name} just got restored {changePoints} HP (now {this.Name} have {this.HP} of HP)!\n");
                }
                else if (changePoints < 0)
                {

                    if ((uint) -changePoints > this.HP)
                        this.HP = 0;
                    else
                        this.HP -= (uint) (-changePoints);

                    Console.WriteLine($"{this.Name} taked {-changePoints} points of damage!\n");

                    if (this.HP <= 0) 
                        this.HP = 0;
                        Console.WriteLine($"{this.Name} just got KOe'd.\n");

                }
            }
        }

        public void MPChange(int changePoints) 
        {
            if (this.MP == this.MaxMP || changePoints == 0)
                Console.WriteLine($"{this.Name} continues with the same MP.\n");
            
            else
            {
                this.MP +=  (uint) changePoints;
                if (changePoints > 0)
                {
                    if (this.MP >= this.MaxMP) 
                    {
                        this.MP = this.MaxMP;
                        Console.WriteLine($"{this.Name} just got restored his MP to the fullest!\n");
                    }
                    else
                        Console.WriteLine($"{this.Name} just got restored {changePoints} MP (now {this.Name} have {this.MP} of MP)!\n");
                }
                else if (changePoints < 0)
                {
                    if ((uint) -changePoints > this.MP)
                        this.MP = 0;
                    else
                        this.MP -= (uint) (-changePoints);


                    if ((uint) (-changePoints) > this.MP)
                        changePoints = -((int) this.MP);

                    Console.WriteLine($"{this.Name} have just lost {-changePoints} MP!\n");

                }
            }
        }

        protected static string AttackAnEnemyMessage(string enemyName)
        {
            if (string.IsNullOrEmpty(enemyName))
            {
                return "";
            }
            else
            {
                return $" the enemy, {enemyName}";
            }
        }

        protected static string AttackWithBonusMessage(int attackBonus)
        {
            if (attackBonus > 6)
            {
                return $"with a strong and major bonus of {attackBonus} points";
            }
            else if (attackBonus > 0)
            {
                return $"with a weak and minor bonus of {attackBonus} points";
            }
            else if (attackBonus == 0)
            {
                return "";
            }
            else if (attackBonus > -6)
            {
                return $"with a minor debuff of {-attackBonus} points";
            }
            else
            {
                return $"with a major debuff of {-attackBonus} points";
            }

        }

        public virtual string Attack()
        {
            return $"{this.Name} attacks!\n";
        }

        public virtual string Attack(int attackBonus = 0, string enemyName = null)
        {
            string bonusAttackMessage = AttackWithBonusMessage(attackBonus);
            string attackAnEnemyMessage = AttackAnEnemyMessage(enemyName);

            if (!string.IsNullOrEmpty(bonusAttackMessage) && !string.IsNullOrEmpty(attackAnEnemyMessage))
            {
                return $"{this.Name} attacks, {bonusAttackMessage},{attackAnEnemyMessage}!\n";
                
            }
            
            return $"{this.Name} attacks, {bonusAttackMessage}{attackAnEnemyMessage}!\n";
        }

        public string LevelUp(uint levelsUpped)
        {
            // O nível máximo de um herói é 99
            // Os pontos de vida e de magia chegam até 999 no máximo
            if (this.Level < 99)
            {
                Random levelUpBonus = new Random();

                uint previousMaxHP = this.MaxHP, previousMaxMP = this.MaxMP;
                uint maxHPBonus = 0, maxMPBonus = 0;

                for (int i = 1; i <= levelsUpped; ++i) 
                {
                    ++this.Level;

                    maxHPBonus += (uint) levelUpBonus.Next(15);
                    maxMPBonus += (uint) levelUpBonus.Next(15);

                    this.MaxHP += maxHPBonus;
                    this.MaxMP += maxMPBonus;
                    
                }

                // HP and MP goes up to 999 at the max
                if (this.MaxHP > 999)
                    this.MaxHP = 999;

                if (this.MaxMP > 999)
                    this.MaxMP = 999;

                // HP and MP  are totally restored when a hero Levels Up
                this.HP = this.MaxHP;
                this.MP = MaxMP;                

                string MaxHPMessage = (previousMaxHP == this.MaxHP)? "Max HP doesn't increase at all." : $"Max HP increases from {previousMaxHP} to {this.MaxHP}!";
                string MaxMPMessage = (previousMaxHP == this.MaxHP)? "Max MP doesn't increase at all." : $"Max MP increases from {previousMaxMP} to {this.MaxMP}!";

                return $"Congratulations! {this.Name} Leveled Up to {this.Level}!\n{MaxHPMessage}\n{MaxMPMessage}\n";
            }
            else
            {
                return "";
            }


        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {{\n\t{this.Name} - {this.HeroClass}\n\tHP: {this.HP}/{this.MaxHP}\n\tMP: {this.MP}/{this.MaxMP}\n}}";
        }
    }
}