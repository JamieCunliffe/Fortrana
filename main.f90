MODULE consts
!Declaration
INTEGER :: TEMPTY=0
INTEGER :: NAVUP=1
INTEGER :: NAVDOWN=2
INTEGER :: NAVLEFT=3
INTEGER :: NAVRIGHT=4

INTEGER :: INPUT1=1
INTEGER :: INPUT2=2
INTEGER :: INPUT3=3
INTEGER :: INPUT4=4
INTEGER :: INPUT5=5

INTEGER :: OBSTACLE1=6
INTEGER :: OBSTACLE2=7
INTEGER :: OBSTACLE3=8 
INTEGER :: OBSTACLE4=9
INTEGER :: OBSTACLE5=10

INTEGER :: MONSTER1=11
INTEGER :: MONSTER2=12 
INTEGER :: MONSTER3=13
INTEGER :: MONSTER4=14
INTEGER :: MONSTER5=15

INTEGER :: KEY1=21
INTEGER :: KEY2=22
INTEGER :: KEY3=23
INTEGER :: KEY4=24
INTEGER :: KEY5=25

INTEGER :: SWORD=69

INTEGER :: NRPOD = 665
INTEGER :: POD = 666

INTEGER :: GRIDMAX = 7
INTEGER :: startX = 4
INTEGER :: startY = 5

END MODULE consts


MODULE Vars
  INTEGER, DIMENSION(0:8,0:8) :: field
  INTEGER currX
  INTEGER currY
  INTEGER tmpX
  INTEGER tmpY
END MODULE Vars
  
INTEGER FUNCTION intRand(u)
  INTEGER u
  intRand = int(rand(0)*u)+1
END FUNCTION intRand


INTEGER FUNCTION init()
  USE Vars
  USE consts
  
  currX = startX 
  currY = startY
 
  print *,'init',currX,currY

  field(0,0) = INPUT1
  field(0,1) = KEY1
  field(0,2) = TEMPTY
  field(0,3) = MONSTER1
  field(0,4) = TEMPTY
  field(0,5) = INPUT2
  field(0,6) = OBSTACLE1
  field(0,7) = SWORD
  
    
  field(1,0) = TEMPTY
  field(1,1) = NRPOD
  field(1,2) = NRPOD
  field(1,3) = NRPOD
  field(1,4) = TEMPTY
  field(1,5) = TEMPTY
  field(1,6) = OBSTACLE1
  field(1,7) = TEMPTY

    
  field(2,0) = TEMPTY
  field(2,1) = NRPOD
  field(2,2) = POD
  field(2,3) = NRPOD
  field(2,4) = OBSTACLE1
  field(2,5) = TEMPTY
  field(2,6) = KEY4
  field(2,7) = TEMPTY

    
  field(3,0) = TEMPTY
  field(3,1) = NRPOD
  field(3,2) = NRPOD
  field(3,3) = NRPOD
  field(3,4) = TEMPTY
  field(3,5) = TEMPTY
  field(3,6) = TEMPTY
  field(3,7) = TEMPTY

  field(4,0) = KEY5 
  field(4,1) = TEMPTY
  field(4,2) = INPUT4
  field(4,3) = OBSTACLE1
  field(4,4) = TEMPTY
  field(4,5) = TEMPTY
  field(4,6) = INPUT3
  field(4,7) = TEMPTY

  field(5,0) = MONSTER1
  field(5,1) = TEMPTY
  field(5,2) = KEY3
  field(5,3) = OBSTACLE1
  field(5,4) = TEMPTY
  field(5,5) = TEMPTY
  field(5,6) = TEMPTY
  field(5,7) = TEMPTY

  field(6,0) = TEMPTY
  field(6,1) = TEMPTY
  field(6,2) = TEMPTY
  field(6,3) = TEMPTY
  field(6,4) = KEY2
  field(6,5) = TEMPTY
  field(6,6) = TEMPTY
  field(6,7) = TEMPTY

  field(7,0) = INPUT5
  field(7,1) = OBSTACLE1
  field(7,2) = OBSTACLE1
  field(7,3) = TEMPTY
  field(7,4) = TEMPTY
  field(7,5) = TEMPTY
  field(7,6) = TEMPTY
  field(7,7) = MONSTER4

  
  init = 1
END FUNCTION init


INTEGER FUNCTION isObstacle( val )
  USE consts
  INTEGER val
  IF( val .EQ. OBSTACLE1 .OR. val .EQ. OBSTACLE2 .OR. val .EQ. OBSTACLE3 .OR. val .EQ. OBSTACLE4 .OR. val .EQ. OBSTACLE5 ) THEN
    isObstacle = 1
  ELSE
    isObstacle = 0
  ENDIF
END FUNCTION isObstacle


INTEGER FUNCTION move(dir)
  USE Vars
  USE consts  
  INTEGER dir
  tmpY = currY
  tmpX = currX 
  IF( DIR .EQ. NAVUP ) THEN
     tmpY = tmpY - 1
  ELSE IF( DIR .EQ. NAVDOWN ) THEN
     tmpY = tmpY + 1
  ELSE IF( DIR .EQ. NAVLEFT ) THEN
     tmpX = tmpX - 1
  ELSE IF( DIR .EQ. NAVRIGHT ) THEN
     tmpX = tmpX + 1
  ENDIF
  IF ( tmpX .GT. 7 ) THEN
     tmpX = 0
  ELSE IF ( tmpX .LT. 0 ) THEN
     tmpX = 7
  ENDIF

  IF ( tmpY .GT. 7 ) THEN
     tmpY = 0
  ELSE IF ( tmpY .LT. 0 ) THEN
     tmpY = 7
  ENDIF

  print *, ''//achar(27)//'[32m **** FORTRANA (c) 1965-1970 (r) Patent Pending **** '//achar(27)//'[0m.'
  IF ( field(tmpY, tmpX) .EQ. POD ) THEN
     print *, ''//achar(27)//'[31m !!! YOU HAVE FALLEN IN THE PIT OF DOOM AND HAVE DIED !!!'//achar(27)//'[0m.'
  ENDIF

  IF( isObstacle( field( tmpY, tmpX ) ) .EQ. 0 ) THEN
    currY = tmpY
    currX = tmpX
    move = field(currY, currX)
  ELSE
    move = 6
  ENDIF
 
  print *,'You are at tile ',tmpY,' long ',tmpX,' lat.  Tile return code is ',field(currY,currX),' direction ',dir

END FUNCTION move

INTEGER FUNCTION GetXPos()
  USE Vars
  GetXPos = currY
END FUNCTION GetXPos

INTEGER FUNCTION GetYPos()
  USE Vars
  GetYPos = currX
END FUNCTION GetYPos
