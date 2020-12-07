
int cellPin = A0;

float aCoefficient = 0,286860655897221;
float bCoefficient = -0,157735967619378;

void setup() 
{
  Serial.begin(9600);
  pinMode(cellPin, INPUT);

}

void loop() 
{
  Serial.print(sunLightIntensity());

}

int sunLightIntensity()
{
  float cell = analogRead(cellPin);

  return (aCoefficient*cell + bCoefficient);
}

