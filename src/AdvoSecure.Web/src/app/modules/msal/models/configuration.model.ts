export class ConfigurationViewModel implements IConfigurationViewModel {
    tenantId?: string | null;
    scope?: string | null;
    clientId?: string | null;
    redirectUrl?: string | null;

    constructor(data?: IConfigurationViewModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.tenantId = _data["tenantId"] !== undefined ? _data["tenantId"] : <any>null;
            this.scope = _data["scope"] !== undefined ? _data["scope"] : <any>null;
            this.clientId = _data["clientId"] !== undefined ? _data["clientId"] : <any>null;
            this.redirectUrl = _data["redirectUrl"] !== undefined ? _data["redirectUrl"] : <any>null;
        }
    }

    static fromJS(data: any): ConfigurationViewModel {
        data = typeof data === 'object' ? data : {};
        let result = new ConfigurationViewModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["tenantId"] = this.tenantId !== undefined ? this.tenantId : <any>null;
        data["scope"] = this.scope !== undefined ? this.scope : <any>null;
        data["clientId"] = this.clientId !== undefined ? this.clientId : <any>null;
        data["redirectUrl"] = this.redirectUrl !== undefined ? this.redirectUrl : <any>null;
        return data;
    }
}

export interface IConfigurationViewModel {
    tenantId?: string | null;
    scope?: string | null;
    clientId?: string | null;
    redirectUrl?: string | null;
}
