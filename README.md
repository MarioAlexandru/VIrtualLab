# VirtualLab
VirtualLab
Linkul pentru versiunea VR: https://github.com/MarioAlexandru/VRLab

Am vrut sa ne bazam in primul rand pe chimie, nu doar pentru ca este materia care da furca multor elevi, dar pentru ca este un subiect care are toate implicatiile in viata reala, cu experimente, observatii...Asa ca am ales Unity, deoarece are multe module de aplicabilitate, Mobile, Desktop, VR.
Acest repository contine si versiunea de mobil si cea de PC.

Tehnologii folosite:
Firebase:
Am folosit un Real time database de la Firebase pentru a stoca scorurile jucatorilor si a le afisa pe un clasament pe varianta de mobil si pentru varianta de PC folosinm PlayerPrefs pentru a stoca local scorurile jucatorilor.

Unity Version Control:
Pentru a putea lucra mai usor in echipa am mai folosit un system de gestionare a codului, Unity Version Control care este direct integrat.
	Scene(Versiunea de PC):
1.  Laborator
Jocul incepe cu scena "Laborator" unde jucatorul se poate misca liber si poate interactiona cu mai multe obiecte (le poate lua in mana, le poate inspecta), explorandul vom da peste 4 alte joculete.

![lab](https://github.com/MarioAlexandru/VirtualLab/blob/main/Assets/Gifs/Laboraor%20Preview.gif)

2.  Compusii chimici Peste 30 de compusi chimici cu denumirea lor.
Acest joculet este accesat prin masa din capatul laboratorului la care poti spawna in laborator compusi chimici pentru a le vedea modelul 3D. Se bazeaza pe o mecanica de Drag and Drop adica vom face legatura dintre formula si numele ei.

![molecule](https://github.com/MarioAlexandru/VirtualLab/blob/main/Assets/Gifs/Molecule%20Preview.gif) ![joculet](https://github.com/MarioAlexandru/VirtualLab/blob/main/Assets/Gifs/Joculet%20Preview.gif)

3.  Adevarat si Fals
Peste 40 de intrebari din materia de liceu si din cultura generala
Toate cele 40 de intrebari sunt verificate de catre profesorul meu de chimie de la clasa. Are un design simplistic, dar eficient si plin de animatii atractive. Intrebarile sunt randomizate si jucatorul se poate juca pana cand doreste.

![quiz](https://github.com/MarioAlexandru/VirtualLab/blob/main/Assets/Gifs/Quiz%20Preview.gif)

5.  Experiment chimic
     Folosind bucla metalică curățată, trebuie sa se ia un eșantion de sare metalică și așezați-l în flacăra becului Bunsen. Jucatorul va observa cu atenție culoarea flăcării, fiecare metal va produce o culoare specifică în flacără.

![flames](https://github.com/MarioAlexandru/VirtualLab/blob/main/Assets/Gifs/Flame%20Preview.gif)
    
5.Labirint
In acest joculet trebuie ca jucatorul sa ghideze lichidul pana la final, avand grija sa nu il polueze de alung. Este integrat un sistem de procente care calculeaza cat la % apa a fost contaminata si iti va oferi un mesaj corespunzator. Fluidul se si coloreaza la contact cu substantele, pentru efect vizual.

![labirint](https://github.com/MarioAlexandru/VirtualLab/blob/main/Assets/Gifs/Labirint%20Preview.gif)

