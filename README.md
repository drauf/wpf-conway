# wpf-conway
Conway's Game of Life implementation using WPF

![screenshot of the application](https://github.com/drauf/wpf-conway/blob/master/screenshot.png?raw=true)

### Areas for improvement
Currently Grid model contains a lot of logic - extract it to a separate class or move it to the view model.  
The project contains only placeholders for tests, listed in the GridTest and LoadSaveServiceTest files. Those should be implemented.

### Original requirements
POL:
```
Aplikcja powinna prezentowac kolejne stany automatu komorkowego Conway's Game of Life
Aplikacja powinna umozliwiac zdefiniowanie wzoru poczatkowego i przegladanie kolejnych pokolen z okreslonym skokiem
Aplikacja powinna umozliwiac okreslenie np. liczbe pokolen, ktore sa kazdorazowo wyliczane, rozmiaru planszy itd. (mozna przyjac jakies rozsadne ograniczenia rozmiaru)
Wskazana mozliwosc wyroznienia komorek umierajacych/nowonarodzonych/obszaru ktory byl juz zamieszkany
Wskazana mozliwosc odczytu/zapisu stanu poczatkowego/biezacego
Aplikacja powinna obejmowac takie mechanizmy/elementy jak Binding, Menu, Okna dialogowe, szablony (prezentacja pojedynczej komorki), style, triggery
Wskazana realizacja presentacji/edycji stanu automatu jako kontrolki (najlepiej z wydzielomym modelem)
```
ENG:
```
The application should present Conway's Game of Life
The application should allow defining the initial pattern and looking at the next generations with the specified jump
The application should allow to customize, for example, the number of generations to be calculated each time, the size of the board, and so on.
Advised to visually differentiate the dying/newborn/area that was already inhabited
Advised to enable reading/writing of the initial/current state
The application should include such mechanisms/elements as Binding, Menu, Dialogs, Templates (single cell presentation), styles, triggers
Recommended implementation of the presentation as a control (preferably with a separate model)
```
