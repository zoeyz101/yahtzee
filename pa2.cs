using System;
using static System.Console;

namespace Bme121
{
    class YahtzeeDice
    {
        Random rGen = new Random();
        
		int[] dice = new int[5];

        public void Roll() 
		{
            for(int i=0; i<5; i++){
                if (dice[i] == 0) { dice[i] = rGen.Next(1, 7); }
			}
		}

        public void Unroll(string faces) 
        { 
            if (faces=="all"){
                for (int i = 0; i < dice.Length; i++) dice[i] = 0;
            }else if(faces.Length >0){ //checks if faces is empty
                foreach (char face in faces){
                    int faceInt = int.Parse(face.ToString()); // converts char to int for comparison
                    for (int i = 0; i < 5; i++) {
                        if (faceInt==dice[i]) dice[i] = 0;
                    }
                }
            }
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < dice.Length; i++) sum += dice[i];
            return sum;
        }

        public int Sum(int face) 
        {
            int sum = 0;
            
            for (int i = 0; i < dice.Length; i++){
                if (face == dice[i]) sum += face;
            }
            
            return sum;
        }

        public bool IsRunOf(int length)
        {
            int counter = 1;
            
            for (int i = 1; i < dice.Length && counter<length; i++){
                if (dice[i]== dice[i-1]+1) counter++; 
            }

            if (counter==length) return true; 
            else return false; 
        }

        public bool IsSetOf(int size)
        {
            int[] counters = new int[6];
            bool rightSize = false;

            for (int i = 1; i < 7; i++){ // runs through dice numbers and checks for the amount of same numbers{
                for (int die = 0; die < dice.Length; die++){
                    if (i == dice[die]) counters[i - 1]++;
                }
            }

            foreach (int counter in counters){
                if (counter >= size) rightSize = true; 
            }

            if (rightSize == true) return true; 
            else return false;
        }

        public bool IsFullHouse()
        {
            int[] counters = new int[6];
            bool sameThree = false;
            bool sameTwo = false;

            for (int i=1; i<7; i++){ // runs through dice numbers and checks for the amount of same numbers
                for (int die=0; die< dice.Length; die++){
                    if (i == dice[die]) counters[i - 1]++;
                }
            }
            
            foreach (int counter in counters){ // sees if there are 2 or 3 of the same number
                if (counter==3) sameThree = true; 
                else if (counter==2) sameTwo = true; 
            }

            if (sameThree == true && sameTwo == true) return true;
            else return false; 
        }

        public override string ToString() // prints the dice values
        {
            Array.Sort(dice); // places the faces in increasing value
            string diceString = string.Join(',', dice);
            return diceString;
        }
    }
}