namespace Hacky.models {


    public struct NotFound { 
        public int? Code;
        public string Message;

    public void ToJson(){
        return JsonUtility.ToJson(this);
    }
    }


}
