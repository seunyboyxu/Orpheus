# Orpheus
A level Computer Science NEA

This is my Computer Science NEA project called Orpheus.

Orpheus is a program that can generate new unique midi files based on parameters you give it like BPM, Key Signiture, Randomness, Pattern Seed and Time Signiture.
My program is made of three parts

Orpheus.cs holds my UI with all my elements

Orpheus_Analyser.cs holds all my functions for an analysis of midi data

Orpheus_MidiMaker.cs creates the unique midi files

My program contains a repository of over 5gb of midi files. The Analysis program analyses every single one of these files and generates usable data that is extracted when making the midi files
This data is stored in a series of json files. This is all run from my LoadMidiFile form in my Orpheus.cs

The Orpheus.cs has a button called generate which will run my MidiMaker program with the parameters i mentioned before.
The Orpheus_MidiMaker program runs in a unique way. It takes the midi files from the generated json files with a specified bpm and time signiture and takes its top 10 used notes.
Based on the keysigniture, the midi maker will generate a set of chords and a set of notes to go over the chords. The patterns are based on predicted patterns made in the JSON data files.

Finally, it exports the Midi File as midi file which can then be played and used in music production or when you need song ideas and you don't know where to start.
