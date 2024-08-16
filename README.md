# 텍스트 이터널 리턴
----------------
- 콘솔 프로젝트로 진행한 텍스트기반 RPG 게임


# 게임 플레이
----
-  ↑ ↓ ← → 를 통해 움직이고 Z키를 통해 선택 가능
- 게임 승리 조건: **현우** 처치
- 플레이어 사망시 패배

### 기본 선택지
![image](https://raw.githubusercontent.com/SeungJu0406/SeungJu0406-KGA_OOPConsoleProject/main/Image/TestImage/%EC%9D%BC%EB%B0%98%20%EC%84%A0%ED%83%9D%EC%A7%80.png)
- 동물 잡기를 통해 고기와 레벨업 가능함
- 이동 하기를 통해 맵 이동이 가능함
- 아이템 확인을 통해 인벤토리를 열 수 있음

### 맵
![image](https://github.com/SeungJu0406/SeungJu0406-KGA_OOPConsoleProject/blob/main/Image/TestImage/%EB%A7%B5.png?raw=true)
- 이동 하기를 통해 맵으로 나올 수 있음
- P는 플레이어 본인 위치
- Z키 입력시 현재 위치에서 다시 선택지로 돌아갈 수 있음
- 각 모서리의 $은 해당 특수 지역(호텔, 골목길, 항구, 병원)
	- 해당 좌표 위에서 Z키 입력시 해당 지역으로 이동할 수 있음
- @는 모닥불, 음식을 구워 상위 아이템으로 만들 수 있음
- H는 "현우"라고 하는 보스 몬스터
	- 현우는 플레이어를 계속 따라오며, 만나면 강제 전투
	- 현우를 처치하면 게임에서 승리한다

### 템 조합
![image](https://github.com/SeungJu0406/SeungJu0406-KGA_OOPConsoleProject/blob/main/Image/TestImage/%EB%8B%A8%EB%B4%89%20%ED%9A%8D%EB%93%9D%EC%8B%9C.png?raw=true)

- 각 지역에는 상자가 있는데 해당 상자에서 조합에 필요한 아이템 획득 가능
- 해당 아이템 획득 시 왼쪽의 필요 아이템의 색이 녹색으로 변한다
![image](https://github.com/SeungJu0406/SeungJu0406-KGA_OOPConsoleProject/blob/main/Image/TestImage/%EC%A1%B0%ED%95%A9%20%ED%85%9C%20%ED%9A%8D%EB%93%9D.png?raw=true)
- 모든 아이템을 획득하면 팔괘장을 획득하며 플레이어의 체력과 공격력이 대폭 증가한다