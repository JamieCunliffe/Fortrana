MODULE Vars
  INTEGER, DIMENSION(0:3,0:3) :: field
  INTEGER currX
  INTEGER currY
END MODULE Vars
  
  
INTEGER FUNCTION intRand(u)
  INTEGER u
  intRand = int(rand(0)*u)+1
END FUNCTION intRand


INTEGER FUNCTION init()
  USE Vars
  field(0,0) = 0
  field(0,1) = 1
  field(0,2) = 2
  field(1,0) = 3
  field(1,1) = 4
  field(1,2) = 5
  field(2,0) = 6
  field(2,1) = 7
  field(2,2) = 8

  init = 1
END FUNCTION init




INTEGER FUNCTION move(dir)
  USE Vars
  
  INTEGER dir
  PRINT *, test
  DO i = 0, 2, 1
    DO j = 0, 2, 1
      PRINT *, field(i,j)
    END DO
  END DO
  
  move = dir
END FUNCTION move
