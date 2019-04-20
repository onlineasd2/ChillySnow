 using UnityEngine;
 
 public class ColorTypeConverter
 {
     public string ToRGBHex(Color c)
     {
         return string.Format("{0:X2}{1:X2}{2:X2}", ToByte(c.r), ToByte(c.g), ToByte(c.b));
     }
 
     private static byte ToByte(float f)
     {
         f = Mathf.Clamp01(f);
         return (byte)(f * 255);
     }
     
    private int HexToDec (string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }
    
    private float HexToFloatNormalized(string hex) {
        return HexToDec(hex) / 255f;
    }

    public Color GetColorFromString(string hexString) {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        return new Color(red, green, blue);
    }
 }