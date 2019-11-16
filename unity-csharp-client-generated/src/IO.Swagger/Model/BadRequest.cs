namespace Hacky.models {


    public struct BadRequest { 
        public int? Code;
        public string Message;

    public void ToJson(){
        return JsonUtility.ToJson(this);
    }
    }


}
