char rec[4]; //variável que irá receber os caracteres vindos da serial
int i=0; //variável de controle para a variável rec

void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

void loop() {

  while(Serial.available())
  {
    rec[i] = (char)Serial.read();

    if(rec[4] == '\r')
    {
      i = 0;

      if((rec[0]=='L') && (rec[1]=='L') && (rec[2]=='1'))
        digitalWrite(13, HIGH);

      if((rec[0]=='D') && (rec[1]=='L') && (rec[2]=='1'))
        digitalWrite(13, HIGH);
    }
    else
      i++;      
  }
}
