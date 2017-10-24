# wpf-conway
Conway's Game of Life implementation using WPF

### Areas for improvement
The UI is displayed as a grid of buttons, backed up by an observable list of observable lists. As a result, if just one cell
changes, the entire grid has to be redrawn. This results in a very sluggish experience when using bigger game boards. The 
application should be updated to only redraw the cells that changed or at least use something more efficient than a grid of 
buttons (like a single canvas).

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
