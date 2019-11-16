namespace Hacky.models {


    public struct Forbidden { 
        public int? Code;
        public string Message;

    public void ToJson(){
        return JsonUtility.ToJson(this);
    }
    }


}
