namespace Hacky.models {


    public struct InternalServerError { 
        public int? Code;
        public string Message;

    public void ToJson(){
        return JsonUtility.ToJson(this);
    }
    }


}
