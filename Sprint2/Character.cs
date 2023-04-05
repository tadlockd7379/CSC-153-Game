namespace Sprint2
{
    class Character
    {
        public string name;
        public double maxHp;
        public double hp;
        public double atk;

        public Character(string name, double maxHp, double atk)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.hp = maxHp;
            this.atk = atk;
        }

        // some methods in the future, such as damage, die, etc.
        // this will also serve as the base class for player in the future
    }
}
