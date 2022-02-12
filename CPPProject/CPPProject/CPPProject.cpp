#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void write_from_stream_to_stream(istream &from, ostream &to) {
    string line;

    while (!from.eof()) {
        getline(from, line);

        if (line != "") {
            to << line << endl;
        } else {
            break;
        }
    }
}

int main() {
    const string PATH = "file.txt";

    // writing from console to file
    ofstream fo(PATH, ios::app);

    if (fo.is_open()) {
        cout << "Enter text:" << endl;

        write_from_stream_to_stream(cin, fo);
    } else {
        cout << "File has not created!";
        return -1;
    }

    fo.close();

    // reading from file to console
    ifstream fi(PATH);

    if (fi.is_open()) {
        cout << "Entered text:" << endl;

        write_from_stream_to_stream(fi, cout);
    } else {
        cout << "File has not created!";
        return -1;
    }

    fi.close();

    //// counting digits
    fi.open(PATH);

    string text = "";

    if (fi.is_open()) {
        string line;
        int count = 1;

        while (!fi.eof()) {
            getline(fi, line);

            if (count++ % 2 == 1) {
                int digits = 0;

                for (int i = 0; i < line.size(); i++) {
                    if ('0' <= line[i] && line[i] <= '9') {
                        digits++;
                    }
                }

                line += " " + to_string(digits);
            }

            text += line + "\n";
        }
    } else {
        cout << "File has not created!";
        return -1;
    }

    fi.close();

    // writing to file
    fo.open(PATH, ios::trunc);

    if (fo.is_open()) {
        fo << text;
    } else {
        cout << "File has not created!";
        return -1;
    }
    fo.close();

    // reading from file to console
    fi.open(PATH);

    if (fi.is_open()) {
        cout << endl << "Parced text:" << endl;

        write_from_stream_to_stream(fi, cout);
    } else {
        cout << "File has not created!";
        return -1;
    }

    return 0;
}
