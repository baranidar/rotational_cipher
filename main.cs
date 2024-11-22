using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class RotationalCipher {
  
  static void Main(String[] args) {
    string cipher = rotationalCipher("abcdefghijklmNOPQRSTUVWXYZ0123456789", 39);
    Console.WriteLine("The final cipher is: {0}", cipher == "-1"? "Invalid input": cipher);
  }
  
  private static string rotationalCipher(String input, int rotationFactor) {
    
    //initialize string
    StringBuilder output = new StringBuilder("");   
    
    //Validate inputs
    if (input.Length < 1 || input.Length > 1000000 || rotationFactor < 0 || rotationFactor > 100000) {
      return "-1";
    }
    Console.WriteLine("Input text is: {0}", input);  
    //Store input
    char[] inputArray = input.ToCharArray();
      
    foreach (char obj in inputArray){
      char charCipher = provideCipher(obj, rotationFactor); 
      output.Append(charCipher);
    }
  
    return output.ToString();
  }
  
  private static char provideCipher(char strChar, int rotationFactor){
    Dictionary<char, int> alphaDict = new Dictionary<char, int>();
    Dictionary<char, int> alphaCapsDict = new Dictionary<char, int>();
    
    alphaDict.Add('a',1);
    alphaDict.Add('b',2);alphaDict.Add('c',3);alphaDict.Add('d',4);alphaDict.Add('e',5);
    alphaDict.Add('f',6);alphaDict.Add('g',7);alphaDict.Add('h',8);alphaDict.Add('i',9);alphaDict.Add('j',10);
    alphaDict.Add('k',11);alphaDict.Add('l',12);alphaDict.Add('m',13);
    alphaDict.Add('n',14);alphaDict.Add('o',15);alphaDict.Add('p',16);
    alphaDict.Add('q',17);alphaDict.Add('r',18);alphaDict.Add('s',19);
    alphaDict.Add('t',20);alphaDict.Add('u',21);alphaDict.Add('v',22);
    alphaDict.Add('w',23);alphaDict.Add('x',24);alphaDict.Add('y',25);alphaDict.Add('z',0);

    alphaCapsDict.Add('A',1);
    alphaCapsDict.Add('B',2);alphaCapsDict.Add('C',3);alphaCapsDict.Add('D',4);alphaCapsDict.Add('E',5);
    alphaCapsDict.Add('F',6);alphaCapsDict.Add('G',7);alphaCapsDict.Add('H',8);alphaCapsDict.Add('I',9);alphaCapsDict.Add('J',10);
    alphaCapsDict.Add('K',11);alphaCapsDict.Add('L',12);alphaCapsDict.Add('M',13);
    alphaCapsDict.Add('N',14);alphaCapsDict.Add('O',15);alphaCapsDict.Add('P',16);
    alphaCapsDict.Add('Q',17);alphaCapsDict.Add('R',18);alphaCapsDict.Add('S',19);
    alphaCapsDict.Add('T',20);alphaCapsDict.Add('U',21);alphaCapsDict.Add('V',22);
    alphaCapsDict.Add('W',23);alphaCapsDict.Add('X',24);alphaCapsDict.Add('Y',25);alphaCapsDict.Add('Z',0);
    
    char[] specialCharacters = "!@#$%^&*()-?".ToCharArray();
    
    int isNumber;
    bool isNumeric = Int32.TryParse(strChar.ToString(), out isNumber);
    bool isSpecialChar = strChar.ToString().IndexOfAny(specialCharacters) == -1 ? false: true;
    
    char typeofChar = isNumeric ? 'N' : isSpecialChar ? 'S' :  'C';
      
    int alphaNumber;
    int numericValueForNumeric; 
    int numericValueForAlpha;
    char retValue = '\0';
 
   if (typeofChar == 'C'){
      
     if(strChar == char.ToUpper(strChar)){
      alphaCapsDict.TryGetValue(strChar, out alphaNumber);
      numericValueForAlpha = ((alphaNumber + rotationFactor) % 26) ;//== 0 ? alphaNumber + rotationFactor : (alphaNumber +   rotationFactor) % 26;
      retValue = alphaCapsDict.FirstOrDefault(x => x.Value == numericValueForAlpha).Key;
     }
     else
     {
      alphaDict.TryGetValue(strChar, out alphaNumber);
      numericValueForAlpha = (alphaNumber + rotationFactor) % 26 ;// == 0 ? alphaNumber + rotationFactor : (alphaNumber + rotationFactor) % 26;
       //Console.WriteLine("Input: {0}, Dict value: {1} Output: {2}", strChar,  alphaNumber, numericValueForAlpha);
      retValue = alphaDict.FirstOrDefault(x => x.Value == numericValueForAlpha).Key; 
     }
     

    }
    else if (typeofChar == 'N')
    {
      numericValueForNumeric = (isNumber + rotationFactor) % 10; //== 0 ? isNumber + rotationFactor :  (isNumber + rotationFactor) % 10;
      retValue = numericValueForNumeric.ToString().ToCharArray()[0];

    }
    else if (typeofChar == 'S')
    {
      retValue = strChar;
      return retValue; 
    }
    else
    {
      //
    }
    
    return retValue;
  }
}
