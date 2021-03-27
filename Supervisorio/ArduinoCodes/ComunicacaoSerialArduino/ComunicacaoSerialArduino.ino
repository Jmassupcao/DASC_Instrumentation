char rec[4]; //variável que irá receber os caracteres vindos da serial
int i=0; //variável de controle para a variável rec
int ad; //variável para armazenar o valor de conversão AD
boolean adc; //variável de controle do conversor AD

char ad_buffer[9]; //variável para armazernar a string de tamanho n, essa variável tem que ter o tamanho n+1

int pinpot = 1; //pino do conversor de AD 

void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

void loop() {

  if(adc)//se a variável adc == TRUE
  {
    ad = analogRead(pinPot);//valor de conversão AD do potenciómetro 

    snprintf(ad_buffer, sizeof(ad_buffer), "ANO=%04d", ad); //formatação do valor ad em string
    Serial.print(ad_buffer); //envia a string para a serial
    delay(300);
  }
}

void serialEvent()
{
  while(Serial.available())
  {
    rec[i]= (char)Serial.read();

    if(rec[i] == '\r')
    {
      i=0;

      if((rec[0]=='I') && (rec[1] == 'N'))
        adc = true;

      if((rec[0]=='F') && (rec[1]=='N'))
        adc = false;
    }
    else
    i++;
  }
}
