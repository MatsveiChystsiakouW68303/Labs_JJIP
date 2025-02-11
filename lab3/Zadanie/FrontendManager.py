from EmployeesManagare import EmployeesManager
from Employee import Employee

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def displayMenu(self):
        print("\nSystem zarządzania pracownikami")
        print("1. Dodaj nowego pracownika")
        print("2. Wyświetl wszystkich pracowników")
        print("3. Usuń pracowników w przedziale wiekowym")
        print("4. Znajdź pracownika po nazwisku")
        print("5. Zaktualizuj wynagrodzenie pracownika")
        print("6. Zakończ")

    def getEmployeeDetails(self):
        name = input("Wprowadź imię i nazwisko pracownika: ")
        age = int(input("Wprowadź wiek pracownika: "))
        salary = float(input("Wprowadź wynagrodzenie pracownika: "))
        return Employee(name, age, salary)

    def start(self):
        while True:
            self.displayMenu()
            choice = input("Wybierz opcję: ")

            if choice == '1':
                employee = self.getEmployeeDetails()
                self.manager.addEmployee(employee)
            elif choice == '2':
                self.manager.displayAllEmployees()
            elif choice == '3':
                minAge = int(input("Podaj minimalny wiek: "))
                maxAge = int(input("Podaj maksymalny wiek: "))
                self.manager.removeEmployeesInAgeRange(minAge, maxAge)
            elif choice == '4':
                name = input("Podaj nazwisko pracownika do wyszukania: ")
                self.manager.findEmployeeByName(name)
            elif choice == '5':
                name = input("Podaj nazwisko pracownika, którego wynagrodzenie chcesz zaktualizować: ")
                newSalary = float(input("Podaj nowe wynagrodzenie: "))
                self.manager.updateEmployeeSalary(name, newSalary)
            elif choice == '6':
                print("Zakończenie systemu.")
                break
            else:
                print("Niepoprawna opcja, spróbuj ponownie.")
