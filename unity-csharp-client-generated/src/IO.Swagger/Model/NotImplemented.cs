namespace Hacky.models {


    public struct NotImplemented { 
        public int? Code;
        public string Message;

    public void ToJson(){
        return JsonUtility.ToJson(this);
    }
    }


}
