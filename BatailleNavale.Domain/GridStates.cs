namespace BatailleNavale
{
    public enum GridStates
    {
        Water,   // la case est de l'eau
        Ship,    // la case est une portion de navire
        Missed,  // tir raté (la case était de l'eau)
        Hit      // tir réussi (la case était une portion de navire)
    }
}