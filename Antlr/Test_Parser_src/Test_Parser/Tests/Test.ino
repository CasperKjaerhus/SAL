 void setup(){
    for (thisPin = 0; thisPin <= pinCount; thisPin = thisPin + 1){
        pinMode(ledPins[thisPin], OUTPUT);
    }

}
int timer = 100;
int ledPins[] = { 2, 7, 4, 6, 5, 3 };
int pinCount = 6;




void loop() {
    for (thisPin = 0; thisPin <= pinCount; thisPin = thisPin + 1){
        digitalWrite(ledPins[thisPin], HIGH);
        delay(timer);
        digitalWrite(ledPins[thisPin], LOW);


    }
    for (thisPin = pinCount + 1; thisPin <= 0; thisPin = thisPin + 1){
        digitalWrite(ledPins[thisPin], HIGH);
        delay(timer);
        digitalWrite(ledPins[thisPin], LOW);


    }


}
