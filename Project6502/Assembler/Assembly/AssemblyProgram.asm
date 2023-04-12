  LDX #$08
loop:
  DEX
  STX $0200
  CPX #$03
  BNE loop
  STX $0201
  BRK