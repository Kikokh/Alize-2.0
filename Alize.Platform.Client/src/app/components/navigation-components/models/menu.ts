// export interface IMenu {
//     name: string;
//     menuName: string;
//     isSelected: boolean;
//     isVisible: boolean;
//     route: string;
//     icon: string;
//     breadcrumb: string;
//     subMenu: IMenu[];
// }

export class MenuItem {
    name: string;
    menuName: string;
    isSelected: boolean;
    isVisible: boolean;
    route: string;
    icon: string;
    breadcrumb: string;
    subMenu: MenuItem[];

    constructor(
        _name: string,
        _menuName: string,
        _isSelected: boolean,
        _isVisible: boolean,
        _route: string,
        _icon: string,
        _breadcrumb: string,
        _subMenu: MenuItem[],
    ) {
        this.name = _name;
        this.menuName = _menuName;
        this.isSelected = _isSelected;
        this.isVisible = _isVisible;
        this.route = _route;
        this.icon = _icon;
        this.breadcrumb = _breadcrumb;
        this.subMenu = _subMenu;
    }

    getOption(menuName: string, optionList: MenuItem[]): MenuItem {
        return optionList.filter(opt => opt.name === menuName)[0];
    }

    showMenuItem(menuItem: MenuItem) {
        menuItem.isVisible = true;
        menuItem.isSelected = true;
    }

    showMenuItemAmongModes(menuItem: MenuItem, optionList: MenuItem[], isCollapsed: boolean) {
        const adminitrationList = ['Aplicaciones', 'Empresas', 'Grupos', 'Modulos', 'Usuarios']
        if (!isCollapsed) {
            if (adminitrationList.includes(menuItem.name)) {
                optionList[1].subMenu.forEach(sub => {
                    if (sub.name === menuItem.name) {
                        sub.isSelected = true;
                    }
                }); 
            } else if (menuItem.name === 'Inicio') {
                optionList[0].subMenu.forEach(sub => {
                    if (sub.name === menuItem.name) {
                        sub.isSelected = true;
                    }
                }); 
            } else {
                optionList[2].subMenu.forEach(sub => {
                    if (sub.name === menuItem.name) {
                        sub.isSelected = true;
                    }
                }); 
            }
        } else {
            if (adminitrationList.includes(menuItem.name)) {
                optionList[1].isVisible = false;
                optionList[1].subMenu.forEach(sub => {
                    if (sub.name === menuItem.name) {
                        sub.isSelected = true;
                    }
                }); 
            } else if (menuItem.name === 'Inicio') {
                optionList[0].isVisible = false;
                optionList[0].subMenu.forEach(sub => {
                    if (sub.name === menuItem.name) {
                        sub.isSelected = true;
                    }
                }); 
            } else {
                optionList[2].isVisible = false;
                optionList[2].subMenu.forEach(sub => {
                    if (sub.name === menuItem.name) {
                        sub.isSelected = true;
                    }
                }); 
            }
        }
     
    }

    ShowSubMenuForSelectedOption(option: MenuItem, itemSelected: MenuItem) {
        option.subMenu.forEach(opt => {
            if (itemSelected && opt.name === itemSelected.name) {
                opt.isSelected = true;
            }
            opt.isVisible = true;
        });
    }

    selectMenuActive(option: MenuItem, optionList: MenuItem[]) {

        this.resetMenuItem(optionList);

        if (option.name === 'Administracion') {
            optionList[1].isSelected = true;
        } else if (option.name === 'Inicio') {
            optionList[0].isSelected = true;
        } else {
            optionList[2].isSelected = true;
        }
    }


    resetMenuItem(optionList: MenuItem[]) {
        optionList.forEach(menu => {
            menu.isSelected = false;
        });
    }

    selectMainMenuActive(option: MenuItem, optionList: MenuItem[]) {
        const adminitrationList = ['Aplicaciones', 'Empresas', 'Grupos', 'Modulos', 'Usuarios']
            if (adminitrationList.includes(option.name)) {
                optionList[1].isSelected = true;
                optionList[1].isVisible = true;
    
            } else if (option.name === 'Inicio') {
                optionList[0].isSelected = true;
                optionList[0].isVisible = true;
    
            } else {
                optionList[2].isSelected = true;
                optionList[2].isVisible = true;
            }
    }

    resetMainMenuStatesVisibleAndEnable(optionList: MenuItem[]) {
        optionList.forEach(menu => {
            menu.isSelected = false;
            menu.isVisible = false;
            menu.subMenu.forEach(sub => {
                sub.isVisible = false;
                sub.isSelected = false;
            });
        });
    }
}