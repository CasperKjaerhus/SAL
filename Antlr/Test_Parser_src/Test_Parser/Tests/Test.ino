 char getFirstChar(string stringInp){
    char firstChar;
    bool isEmpty = true;
    WRONG strLength = getStringLength(stringInp);
    if(strLength > 0;){
        isEmpty = false;
    }
    if(isEmpty){
        firstChar = stringInp[0];
    }
    return firstChar;






}
int getStringLength(string stringInp){
    return 1;

}


void setup() {
}

void loop() {
    string stringVar = "This is a string";
    Serial.Print(getFirstChar(stringVar););


}
