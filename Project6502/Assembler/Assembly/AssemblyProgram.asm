JMP loadTwo

loadOne:
LDA #$11
JMP store

loadTwo:
LDA #$22
JMP store

store:
STA $0200