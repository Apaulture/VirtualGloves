/******************************************************************************
Flex_Sensor_Example.ino
Example sketch for SparkFun's flex sensors
  (https://www.sparkfun.com/products/10264)
Jim Lindblom @ SparkFun Electronics
April 28, 2016

Create a voltage divider circuit combining a flex sensor with a 47k resistor.
- The resistor should connect from A0 to GND.
- The flex sensor should connect from A0 to 3.3V
As the resistance of the flex sensor increases (meaning it's being bent), the
voltage at A0 should decrease.

Development environment specifics:
Arduino 1.6.7
******************************************************************************/
 // Pin connected to voltage divider output
const int THUMB_PIN = A0;
const int INDEX_PIN = A1;
const int MID_PIN = A2;
const int RING_PIN = A3;
const int PINKY_PIN = A4;

// Measure the voltage at 5V and the actual resistance of your
// 47k resistor, and enter them below:
const float VCC = 5.0; // Measured voltage of Ardunio 5V line
const float R_DIV = 10000.0; // Resistance of the series resistor

// Upload the code, then try to adjust these values to more
// accurately calculate bend degree.
//Each sensor has different straight & bend resistances, so these need to be updated.
const float INDEX_STRAIGHT_RESISTANCE = 31926.0; // resistance when straight
const float INDEX_BEND_RESISTANCE = 61500.0; // resistance at 90 deg
const float THUMB_STRAIGHT_RESISTANCE = 29045.0;
const float THUMB_BEND_RESISTANCE = 31926.40;
const float MID_STRAIGHT_RESISTANCE = 30430.78;
const float MID_BEND_RESISTANCE = 71000.30;
const float RING_STRAIGHT_RESISTANCE = 35874.49;
const float RING_BEND_RESISTANCE = 54000.56;
const float PINKY_STRAIGHT_RESISTANCE = 25275.92;
const float PINKY_BEND_RESISTANCE = 42000.10;


void setup() 
{
  Serial.begin(57600); //57600
  
  pinMode(THUMB_PIN, INPUT);
  pinMode(INDEX_PIN, INPUT);
  pinMode(MID_PIN, INPUT);
  pinMode(RING_PIN, INPUT);
  pinMode(PINKY_PIN, INPUT);
}

void loop() 
{
  

//Repeat for thumb sensor
  int thumbADC = analogRead(THUMB_PIN);
  float thumbV = thumbADC * VCC / 1023.0;
  float thumbR = R_DIV*thumbV/(VCC-thumbV);
  int thumb_angle = map(thumbR, THUMB_STRAIGHT_RESISTANCE, THUMB_BEND_RESISTANCE,
                   0, 90.0);

  // Use the calculated resistance to estimate the sensor's
  // bend angle:
  // Read the ADC, and calculate voltage and resistance from it
  int indexADC = analogRead(INDEX_PIN);
  float indexV = indexADC * VCC / 1023.0;
  float indexR = R_DIV*indexV/(VCC-indexV);
  int index_angle = map(indexR, INDEX_STRAIGHT_RESISTANCE, INDEX_BEND_RESISTANCE,
                   0, 90.0);
       
 //Repeat for middle
  int midADC = analogRead(MID_PIN);
  float midV = midADC * VCC / 1023.0;
  float midR = R_DIV*midV/(VCC-midV);

  int mid_angle = map(midR, MID_STRAIGHT_RESISTANCE, MID_BEND_RESISTANCE,
                   0, 90.0);

 //Repeat for ring
  int ringADC = analogRead(RING_PIN);
  float ringV = ringADC * VCC / 1023.0;
  float ringR = R_DIV*ringV/(VCC-ringV);

  int ring_angle = map(ringR, RING_STRAIGHT_RESISTANCE, RING_BEND_RESISTANCE,
                   0, 90.0);

 //repeat for pinky
  int pinkyADC = analogRead(PINKY_PIN);
  float pinkyV = pinkyADC * VCC / 1023.0;
  float pinkyR = R_DIV*pinkyV/(VCC-pinkyV);

  int pinky_angle = map(pinkyR, PINKY_STRAIGHT_RESISTANCE, PINKY_BEND_RESISTANCE,
                   0, 90.0);


  

  Serial.print(thumb_angle);
  Serial.print(",");
  Serial.print(index_angle);
  Serial.print(",");
  Serial.print(mid_angle);
  
  Serial.print(",");
  Serial.print(ring_angle);
  Serial.print(",");
  Serial.print(pinky_angle);
  
  Serial.println();
  
  delay(5);
}
