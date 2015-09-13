#pragma strict

var result:boolean;
var toCheck:String;
 
//function Update(){
//
//    if(Input.GetKeyUp("v")){
//        result = VerifyEmailAddress(toCheck);
//        print("Checked " + toCheck + " result is " + result);
//    }
//}
 
 
static function VerifyEmailAddress(address:String){
    var atCharacter:String[];
    var dotCharacter:String[];
    atCharacter = address.Split("@"[0]);
    if(atCharacter.Length == 2){
        dotCharacter = atCharacter[1].Split("."[0]);
        if(dotCharacter.Length >= 2){
            if(dotCharacter[dotCharacter.Length - 1].Length == 0){
                return false;
            }
            else{
                return true;
            }
        }
        else{
            return false;
        }
    }
    else{
        return false;
    }
}
 